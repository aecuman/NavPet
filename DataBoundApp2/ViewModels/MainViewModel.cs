using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DataBoundApp2.Resources;
using System.Net;
using Newtonsoft.Json;
using DataBoundApp2.Models;

namespace DataBoundApp2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        const string apiUrl = @"http://navp.apphb.com/api/StationApi";
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        
        public ObservableCollection<ItemViewModel> Items { get; private set; }
       

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            if (this.IsDataLoaded==false)
            {
                this.Items.Clear();
                this.Items.Add(new ItemViewModel(){ ID = "0", LineOne = "Kindly", LineTwo = "Please wait ...", LineThree = null, LineFour=null });
                WebClient webClient = new WebClient();
                webClient.Headers["Accept"] = "application/json";
                
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClent_DownloadStationsCompleted);
                webClient.DownloadStringAsync(new Uri(apiUrl));
            }
        }
            public void webClent_DownloadStationsCompleted (object sender,DownloadStringCompletedEventArgs e)
            {
                try{
                    this.Items.Clear();
                    if (e.Result!=null)
                    {
                        var stations=JsonConvert.DeserializeObject<Station[]>(e.Result);
                        int id=0;
                        foreach (Station station in stations)
                        {
                            this.Items.Add(new ItemViewModel()
                            {
                                ID=(id++).ToString(),LineOne=station.Name,LineThree=station.Petrol,LineTwo=station.Diesel,LineFour=station.By
                            });
                        }
                        this.IsDataLoaded=true;
                    }
                }
                catch (Exception ex)
                {
                    this.Items.Add(new ItemViewModel()
                    {
                        ID="0",LineOne="Error Occured",LineTwo=String.Format("The following Exception Occured:{0}",ex.Message),LineThree=String.Format("Additional inner exception information:{0}",ex.InnerException.Message)
                    });
                }
            }
            // Sample data; replace with real data
           
           
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        
    }
}
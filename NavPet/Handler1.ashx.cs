using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JsonServices;
using JsonServices.Web;
using NavPet.Models;

namespace NavPet
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : JsonHandler
    {

        public Handler1()
        {
            this.service.Name = "Json";
            this.service.Description = "JSON API for android application";
            InterfaceConfiguration IConfig = new InterfaceConfiguration("RestAPI", typeof(IStationRepository), typeof(StationRepository));
            this.service.Interfaces.Add(IConfig);
        }
    }
}
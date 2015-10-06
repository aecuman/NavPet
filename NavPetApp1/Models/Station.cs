using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavPetApp1.Models
{
    class Station
    {

        
        public string Id { get; set; }
        public string Name { get; set; }
       
        public string Petrol { get; set; }
    
        public string Diesel { get; set; }
       

        public string UnleadedExtra { get; set; }
      
        public string By { get; set; }
        public DateTime LastModified { get; set; }
    }
}

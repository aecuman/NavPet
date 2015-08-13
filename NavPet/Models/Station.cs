using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace NavPet.Models
{
    public class Station
    {
        [BsonId]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string loc { get; set; }
        [StringLength(4, ErrorMessage = "Price is incomplete")]
        public string Petrol { get; set; }
        [StringLength(4, ErrorMessage = "Price is incomplete")]
        public string Diesel { get; set; }       
        [Required]
        public string Contact { get; set; }
        public DateTime LastModified { get; set; }
       
    }
}
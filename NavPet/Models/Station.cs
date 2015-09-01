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
        public string Name { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "Price is incomplete",MinimumLength=4)]
        [RegularExpression("[1-9][0-9]*", ErrorMessage = "The Price of Petrol must be a natural number")]
        public string Petrol { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "Price is incomplete",MinimumLength=4)]
        [RegularExpression("[1-9][0-9]*", ErrorMessage = "The Price of Diesel must be a natural number")]
        public string Diesel { get; set; }
        [StringLength(4, ErrorMessage = "Price is incomplete", MinimumLength = 4)]
        [RegularExpression("[1-9][0-9]*", ErrorMessage = "The Price of UnleadedExtra must be a natural number")]
        
        public string UnleadedExtra { get;set;}
        [Required(ErrorMessage="Please Add your name")]  
        [RegularExpression("^[a-zA-Z]*$",ErrorMessage="Insert your Name without figures")]
        public string By { get; set; }
        public DateTime LastModified { get; set; }
       
    }
}
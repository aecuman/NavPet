using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NavPet.Models.Userprofiles
{
    public class Profiles
    {
        [BsonId]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Company { get; set; }
        public string Stationgroup { get; set; }
        public string loc { get; set; }
        public string place { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
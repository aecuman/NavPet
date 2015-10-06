using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;
using System.Configuration;

namespace NavPet.Models
{
    public class StationRepository:IStationRepository
    {
        public StationRepository()
            : this("")
        {
        }
        MongoServer _server;
        MongoDatabase _database;
        MongoCollection<Station> _station;
         public StationRepository(string connection)
    {
        if (string.IsNullOrWhiteSpace(connection))
       {
           //connection = "mongodb://appharbor_zch30534:vierusjv3qn2ma2imfo3sqqos2@ds035623.mongolab.com:35623/appharbor_zch30534";
           connection = "mongodb://localhost:27017";
       }
        MongoClient mongoClient = new MongoClient( connection);
        //_database = mongoClient.GetServer().GetDatabase("appharbor_zch30534");
        _database = mongoClient.GetServer().GetDatabase("NavPet");
       _station = _database.GetCollection<Station>("Stations");
    
       // Reset database and add some default entries
       
        //MongoServer _server;
        //MongoDatabase _database;
        /// <summary>
        /// 
        /// </summary>
       
        /*
readonly MongoDatabase mongoDatabase;

MongoCollection<Station> _station;
        public StationRepository()
            {
           mongoDatabase=RetreiveMongohqDb();
        }
        private MongoDatabase RetreiveMongohqDb()
        {
            MongoClient mongoClient = new MongoClient(
                new MongoUrl(ConfigurationManager.ConnectionStrings
                 ["conn"].ConnectionString));
          //  MongoServer server = mongoClient.GetServer();
            return mongoClient.GetServer().GetDatabase("test");
            _station = mongoDatabase.GetCollection<Station>("station");
             //_station= mongoDatabase.GetCollection("station");
           
           // _station.RemoveAll();
        /* }
            : this("")
         {
         }
         public StationRepository(string con)
         { 
             if (string.IsNullOrWhiteSpace(con))
         {
             con = "mongodb://localhost:27017";
         }
             // var _server = MongoClient.(con);
             MongoClient mongoClient = new MongoClient(con);
             MongoServer server = mongoClient.GetServer();
             var _database=mongoClient.GetServer().GetDatabase("test");
            /* var client = new MongoClient("mongodb://localhost:27017");
             _server = client.GetServer();
             var _database = _server.GetDatabase("test");
             var _station = _database.GetCollection<Station>("station");
            */
             /*for (int index = 1; index < 5; index++)
             {
                 Station station1 = new Station
                 {
                     //Petrol = string.Format("{0},{0}{0}{0}", index),
                    // Name = string.Format("test{0}", index),
                     //Diesel = string.Format("{0},{0}{0}{0}", index),
                    // Contact = string.Format("{0}{0}{0}{0} {0}{0}{0} {0}{0}{0}", index),
                   //  Email = string.Format((@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"), index)
                 };
                 AddStation(station1);
                
             }*/

             
         }

        public IEnumerable<Station> GetAllStations()
        {
          /*  List<Station> model = new List<Station>();
            var stationList = mongoDatabase.GetCollection("station").FindAll().AsEnumerable();
            model = (from station in stationList
                     select new Station
                     {
                         Id = station["_id"].AsString,
                         Petrol = station["Petrol"].AsString,
                         Diesel = station["Diesel"].AsString,
                         //loc = station(["loc"].AsBsonDocument).AsString,

                     }).ToList();
            return model;*/
          
           return _station.FindAll();
        }
        public Station GetStation(string Id)
        {
            IMongoQuery query = Query.EQ("_id", Id);
            return _station.Find(query).FirstOrDefault();

        }
        public Station AddStation(Station item)
        {
            item.Id = ObjectId.GenerateNewId().ToString();
            item.LastModified = DateTime.UtcNow;
            _station.Insert(item);
            return item;
        }
        public bool RemoveStation(string Id)
        {
            IMongoQuery query = Query.EQ("_id", Id);
            WriteConcernResult result = _station.Remove(query);
            return result.DocumentsAffected == 1;
        }
        public bool UpdateStation(string Id, Station item)
        {
            IMongoQuery query = Query.EQ("_id", Id);

            IMongoUpdate update = Update

                //.Set("UnleadedExtra", item.UnleadedExtra)
                .Set("Petrol", item.Petrol)
                .Set("Diesel", item.Diesel);
                //.Set("UnleadedExtra",item.UnleadedExtra)
               // .Set("LastModified", DateTime.UtcNow)
                //.Set("By", item.By);
               
            item.LastModified = DateTime.UtcNow;
            WriteConcernResult result = _station.Update(query, update);
            return result.UpdatedExisting;
        }
    }
}
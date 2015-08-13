using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;

namespace NavPet.Models
{
    public class StationRepository:IStationRepository
    {
        MongoServer _server;
        //MongoDatabase _database;
        MongoCollection<Station> _station;

        public StationRepository()
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

            var client = new MongoClient("mongodb://localhost:27017");
            _server = client.GetServer();
            var _database = _server.GetDatabase("test");
            var _station = _database.GetCollection<Station>("station");

            for (int index = 1; index < 5; index++)
            {
                Station station1 = new Station
                {
                    Petrol = string.Format("{0},{0}{0}{0}", index),
                    Name = string.Format("test{0}", index),
                    Diesel = string.Format("{0},{0}{0}{0}", index),
                    Contact = string.Format("{0}{0}{0}{0} {0}{0}{0} {0}{0}{0}", index),
                  //  Email = string.Format((@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"), index)
                };
                AddStation(station1);
            }

        }

        public IEnumerable<Station> GetAllStations()
        {
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
                .Set("Name", item.Name)
                .Set("Company", item.Company)
                .Set("loc", item.loc)
                .Set("Petrol", item.Petrol)
                .Set("Diesel", item.Diesel)
                .Set("LastModified", DateTime.UtcNow)
                .Set("Contact", item.Contact);
               
            item.LastModified = DateTime.UtcNow;
            WriteConcernResult result = _station.Update(query, update);
            return result.UpdatedExisting;
        }
    }
}
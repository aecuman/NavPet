using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavPet.Models.Userprofiles
{
    public class ProfilesRepository:IProfilesRepository
    {
        public ProfilesRepository()
            : this("")
        {
        }
        MongoServer _server2;
        MongoDatabase _database2;
        MongoCollection<Profiles> _profiles;
        public ProfilesRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = "mongodb://appharbor_256pbwmk:b6c34l7k05n49j3qujo5rukiti@ds029824.mongolab.com:29824/appharbor_256pbwmk";
               // connection = "mongodb://localhost:27017";
            }
            MongoClient mongoClient = new MongoClient(connection);
            //_database = mongoClient.GetServer().GetDatabase("appharbor_zch30534");
            _database2 = mongoClient.GetServer().GetDatabase("Station");
            _profiles = _database2.GetCollection<Profiles>("UserProfile");

        }
        public IEnumerable<Profiles> GetAllProfiles()
        {
            return _profiles.FindAll();
        }
        public Profiles GetProfile(string Id)
        {
            IMongoQuery query = Query.EQ("_id", Id);
            return _profiles.Find(query).FirstOrDefault();

        }
        public Profiles AddProfile(Profiles item)
        {
            item.Id = ObjectId.GenerateNewId().ToString();

            _profiles.Insert(item);
            return item;
        }
        public bool RemoveProfile(string Id)
        {
            IMongoQuery query = Query.EQ("_id", Id);
            WriteConcernResult result = _profiles.Remove(query);
            return result.DocumentsAffected == 1;
        }
        public bool UpdateProfile(string Id, Profiles item)
        {
            IMongoQuery query = Query.EQ("_id", Id);

            IMongoUpdate update = Update
                .Set("UserName", item.UserName)
                .Set("Company", item.Company)
                .Set("Stationgroup", item.Stationgroup)
                .Set("loc", item.loc)
                .Set("Mobile", item.Mobile)
                .Set("Email", item.Email)
                .Set("place", item.place);
            //.Set("UnleadedExtra", item.UnleadedExtra)
            // .Set("Petrol", item.Petrol)
            // .Set("Diesel", item.Diesel);
            //.Set("UnleadedExtra",item.UnleadedExtra)
            // .Set("LastModified", DateTime.UtcNow)
            //.Set("By", item.By);


            WriteConcernResult result = _profiles.Update(query, update);
            return result.UpdatedExisting;
        }
    }
}
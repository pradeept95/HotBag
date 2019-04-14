using HotBag.EntityBase;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HotBag.MongoDb.Context
{
    public interface IMongoDbContext
    {
        IMongoCollection<ApplicationSettings> ApplicationSettings { get; }
        //IMongoCollection<EditionFeatureSetting> EditionFeatureSettings { get; }

    }

    public class ApplicationSettings : EntityBase<ObjectId>
    {
        public string ApplicationName { get; set; } 
    }
}

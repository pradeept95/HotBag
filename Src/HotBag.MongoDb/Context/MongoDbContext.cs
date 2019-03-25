using HotBag.DI.Base;
using HotBag.OptionConfigurer.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HotBag.MongoDb.Context
{
    public class MongoDbContext : ISingletonService, IMongoDbContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<ApplicationSettings> ApplicationSettings
        {
            get
            {
                return _database.GetCollection<ApplicationSettings>("ApplicationSettings");
            }
        }

        //public IMongoCollection<EditionFeatureSetting> EditionFeatureSettings
        //{
        //    get
        //    {
        //        return _database.GetCollection<EditionFeatureSetting>("EditionFeatureSettings");
        //    }
        //}
    }
}

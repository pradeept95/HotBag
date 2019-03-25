using HotBag.EntityBase;
using HotBag.MongoDb.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace HotBag.MongoDb.Seed.Host
{
    public static class SeedHostDatabase
    {
        public async static Task Start(IMongoDbContext mongoDbContext)
        {
            var appSetting = new ApplicationSettings 
            { 
                ApplicationName = "HotBag Enterprise Application"
            };

            FilterDefinition<ApplicationSettings> filter = Builders<ApplicationSettings>.Filter.Eq(m => m.ApplicationName, appSetting.ApplicationName);
            if (await mongoDbContext.ApplicationSettings.FindAsync(filter).Result.AnyAsync())
            {
                return;
            } 

            await mongoDbContext.ApplicationSettings.InsertOneAsync(appSetting);
        }
    }
}

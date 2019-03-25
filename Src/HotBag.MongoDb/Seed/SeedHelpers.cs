using HotBag.MongoDb.Context;
using HotBag.MongoDb.Seed.Host;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace HotBag.MongoDb.Seed
{
    public static class SeedHelpers 
    {
        public async static Task SeedMongoData(IServiceCollection serviceCollection)
        {
            IMongoDbContext mongoDbContext = serviceCollection.BuildServiceProvider()?.GetService<IMongoDbContext>();
            if(mongoDbContext != null)
            {
               await SeedHostDatabase.Start(mongoDbContext);
            } 
        }
    }
}

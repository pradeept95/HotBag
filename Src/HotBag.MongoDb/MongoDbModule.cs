using HotBag.DI.Base;
using HotBag.Modules;
using HotBag.MongoDb.Seed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag
{
    public class MongoDbModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "MongoDbModule"; }

        } 
         
        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            SeedHelpers.SeedMongoData(serviceCollection).Wait();
        } 
    }
}

using HotBag.Modules;
using HotBag.MongoDb.Seed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.MongoDb
{
    public class MongoDbModule : ApplicationModule
    {
        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
          
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            SeedHelpers.SeedMongoData(serviceCollection).Wait();
        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
           
        }
    }
}

using HotBag.DI.Base;
using HotBag.Modules;
using HotBag.MongoDb.Seed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag
{
    public class MongoDbModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "MongoDbModule"; }

        } 

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
          
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            SeedHelpers.SeedMongoData(serviceCollection).Wait();
        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Scan(scan => scan
           .FromAssemblyOf<MongoDbModule>()
               .AddClasses(classes => classes.AssignableTo<ITransientDependencies>())
                   .AsImplementedInterfaces()
                   .WithTransientLifetime()

               .AddClasses(classes => classes.AssignableTo<IScopedDependencies>())
                   .As<IScopedDependencies>()
                   .WithScopedLifetime()

                .AddClasses(classes => classes.AssignableTo<ISingletonDependencies>())
                           .AsImplementedInterfaces()
                           .WithSingletonLifetime());
        }
    }
}

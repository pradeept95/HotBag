using HotBag.DI;
using HotBag.DI.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.MongoDb
{
    public class MongoDbServiceRegistrar : IServiceRegistrar
    {
        public void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Scan(scan => scan
             .FromAssemblyOf<MongoDbModule>()
                 .AddClasses(classes => classes.AssignableTo<ITransientService>())
                     .AsImplementedInterfaces()
                     .WithTransientLifetime()

                 .AddClasses(classes => classes.AssignableTo<IScopedService>())
                     .As<IScopedService>()
                     .WithScopedLifetime()

                  .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                             .AsImplementedInterfaces()
                             .WithSingletonLifetime());
        }

        public void Update(IServiceCollection serviceCollection)
        {
             
        }
    }
}

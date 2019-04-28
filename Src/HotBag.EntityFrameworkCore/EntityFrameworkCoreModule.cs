using HotBag.DI.Base;
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag
{
    public class EntityFrameworkCoreModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "EntityFrameworkCoreModule"; }

        }
         
        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
             
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //SeedHelpers.SeedData(serviceCollection);
        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Scan(scan => scan
             .FromAssemblyOf<EntityFrameworkCoreModule>()
                 .AddClasses(classes => classes.AssignableTo<ITransientDependencies>())
                     .AsImplementedInterfaces()
                     .WithTransientLifetime()

                 .AddClasses(classes => classes.AssignableTo<IScopedDependencies>())
                     .AsImplementedInterfaces()
                     .WithScopedLifetime()

                  .AddClasses(classes => classes.AssignableTo<ISingletonDependencies>())
                             .AsImplementedInterfaces()
                             .WithSingletonLifetime());

        }
    }
}

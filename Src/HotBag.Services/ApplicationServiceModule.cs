using HotBag.DI.Base;
using HotBag.Modules;
using HotBag.Services.RepositoryFactory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Services
{
    public class ApplicationServiceModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "ApplicationServiceModule"; } 
        } 

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //serviceCollection.Scan(scan => scan
            //  .FromAssemblyOf<ApplicationServiceModule>()
            //      .AddClasses(classes => classes.AssignableTo<ITransientDependencies>())
            //          .AsImplementedInterfaces()
            //          .WithTransientLifetime()

            //      .AddClasses(classes => classes.AssignableTo<IScopedDependencies>())
            //          .As<IScopedDependencies>()
            //          .WithScopedLifetime()

            //       .AddClasses(classes => classes.AssignableTo<ISingletonDependencies>())
            //                  .AsImplementedInterfaces()
            //                  .WithSingletonLifetime());

            //serviceCollection.AddScoped(typeof(IRepositoryFactory<,>), typeof(RepositoryFactory<,>));  
        }
    }
}

using HotBag.DI;
using HotBag.DI.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace HotBag.Web.Core
{
    public class WebCoreServiceRegistrar : IServiceRegistrar
    {
        public void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //serviceCollection.AddTransient<IMasterCompanyService, MasterCompanyService>();

            serviceCollection.Scan(scan => scan
                 .FromAssemblyOf<WebCoreModule>()
                     .AddClasses(classes => classes.AssignableTo<ITransientDependencies>())
                         .AsImplementedInterfaces()
                         .WithTransientLifetime()

                     .AddClasses(classes => classes.AssignableTo<IScopedDependencies>())
                         .As<IScopedDependencies>()
                         .WithScopedLifetime() 

              .AddClasses(classes => classes.AssignableTo<ISingletonDependencies>())
                         .AsImplementedInterfaces()
                         .WithSingletonLifetime());
            // throw new NotImplementedException();
        }

        public void Update(IServiceCollection serviceCollection)
        {
           // throw new NotImplementedException();
        }
    }
}

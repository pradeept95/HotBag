using HotBag.DI;
using HotBag.DI.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Services
{
    public class ApplicationServiceRegistrar : IServiceRegistrar
    {
        public void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Scan(scan => scan
               .FromAssemblyOf<ApplicationServiceModule>()
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

        public void Update(IServiceCollection serviceCollection)
        {
           
        }
    }
}

using HotBag.DI.Base;
using HotBag.Modules;
using HotBag.Services.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Services
{
    public class ApplicationServiceModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "ApplicationServiceModule"; } 
        }

        public override bool IsInstalled
        {
            get { return true; }

        }

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
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

            serviceCollection.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();  
        }
    }
}

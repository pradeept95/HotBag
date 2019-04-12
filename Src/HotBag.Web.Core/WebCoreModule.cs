using HotBag.DI.Base;
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Web.Core
{
    public class WebCoreModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "WebCoreModule"; }

        }

        public override bool IsInstalled
        {
            get { return true; }

        }

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //throw new NotImplementedException(); 
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //throw new NotImplementedException();


        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //throw new NotImplementedException();

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
        }
    }
}

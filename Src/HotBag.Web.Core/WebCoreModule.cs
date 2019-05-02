using HotBag.DI.Base;
using HotBag.Modules;
using HotBag.Web.Core.Web;
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
 
        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //throw new NotImplementedException(); 
            serviceCollection
                   .AddMvc(
                        //o => o.Conventions.Add(new GenericControllerRouteConvention())
                   ).
                    ConfigureApplicationPartManager(m =>
                        m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider()
                    ));
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

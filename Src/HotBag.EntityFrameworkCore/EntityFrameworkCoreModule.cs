using HotBag.DI.Base;
using HotBag.EntityFrameworkCore.Context;
using HotBag.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.EntityFrameworkCore
{
    public class EntityFrameworkCoreModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "EntityFrameworkCoreModule"; }

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

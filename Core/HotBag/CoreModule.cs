using HotBag.AuthConfiguration;
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag
{
    public class CoreModule : ApplicationModule
    {
        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        { 

        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            AuthConfigurer.Configure(serviceCollection, configuration);
        }
    }
}

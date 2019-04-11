using HotBag.Modules;
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
            
        }
    }
}

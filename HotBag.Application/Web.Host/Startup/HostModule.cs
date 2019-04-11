using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Web.Host
{
    public class HostModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "HostModule"; }

        }

        public override bool IsInstalled
        {
            get { return true; }

        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

    }
}

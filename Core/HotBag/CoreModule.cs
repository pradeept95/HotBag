using HotBag.AuthConfiguration;
using HotBag.Modules;
using HotBag.OptionConfigurer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            serviceCollection.ConfigureApplicationSettings(configuration);
            AuthConfigurer.Configure(serviceCollection, configuration); 
        }
    }
}

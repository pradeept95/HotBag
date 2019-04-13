
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace HotBag.Plugins.Email
{
    public class HotBagEmailModuel : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "HotBagEmailModuel"; }

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
            var currentDir = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                 .SetBasePath(currentDir)
                 .AddJsonFile("emailsettings.json", optional: false, reloadOnChange: true);
                  

            IConfigurationRoot config = builder.Build();
            serviceCollection.ConfigureEmailSettings(config);
        }
    }
}

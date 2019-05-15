
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace HotBag.Plugins.Email
{
    public class HotBagEmailModuel : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "HotBagEmailModuel"; }

        } 

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        { 
            var filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var builder = new ConfigurationBuilder()
                 .SetBasePath(filePath)
                 .AddJsonFile("emailsettings.json", optional: false, reloadOnChange: true);
                  

            IConfigurationRoot config = builder.Build();
            serviceCollection.ConfigureEmailSettings(config);
        }
    }
}

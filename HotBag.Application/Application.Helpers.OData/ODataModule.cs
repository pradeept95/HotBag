using HotBag.Modules;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Plugins.OData
{
    public class ODataModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "ODataModule"; } 
        } 

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
           
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        { 

        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOData();
            serviceCollection.AddODataQueryFilter(); 
        }
    }

}

using HotBag.DI.Base;
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag
{
    public class EntityFrameworkCoreModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "EntityFrameworkCoreModule"; } 
        }
          
        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //SeedHelpers.SeedData(serviceCollection);
        } 
    }
}

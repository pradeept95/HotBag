using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Plugins.GraphQl
{
    public class GraphQLModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "GraphQLModule"; } 
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

using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Modules
{
    public abstract class ApplicationModule : IApplicationModule
    {
        public abstract void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration);

        public abstract void Initialize(IServiceCollection serviceCollection, IConfiguration configuration); 

        public abstract void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration); 
    }

}

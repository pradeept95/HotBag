using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Modules
{
    public interface IApplicationModule
    {
        // void Register(IServiceCollection serviceCollection);
        void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration);
        void Initialize(IServiceCollection serviceCollection, IConfiguration configuration);
        void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}

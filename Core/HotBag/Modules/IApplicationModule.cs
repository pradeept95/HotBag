using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Modules
{
    public interface IApplicationModule
    {
        // void Register(IServiceCollection serviceCollection);
        string ModuleName { get; }

        bool IsInstalled { get; }

        void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration);
        void Initialize(IServiceCollection serviceCollection, IConfiguration configuration);
        void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}

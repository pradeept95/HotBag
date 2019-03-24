using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.DI
{
    public interface IServiceRegistrar
    {
        // void Register(IServiceCollection serviceCollection);
        void Update(IServiceCollection serviceCollection);
        void Register(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}

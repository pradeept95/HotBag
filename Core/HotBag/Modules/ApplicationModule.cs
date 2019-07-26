 using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Modules
{
    public abstract class ApplicationModule : IApplicationModule
    { 
        public abstract string ModuleName { get; }
        public virtual void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration) { }

        public virtual void Initialize(IServiceCollection serviceCollection, IConfiguration configuration) { }

        public virtual void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration) { }
    }
}

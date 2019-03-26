using System.Text;
using HotBag.AutoMaper;
using HotBag.Identity.AppSession;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Modules
{
    public abstract class ApplicationModule : IApplicationModule
    {
        protected readonly IAppSession AppSession;
        private readonly IObjectMapper ObjectMapper;
        public ApplicationModule()
        {
            AppSession = NullAppSession.Instance;
            ObjectMapper = NullObjectMapper.Instance;
        }
         
        public abstract void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration);

        public abstract void Initialize(IServiceCollection serviceCollection, IConfiguration configuration); 

        public abstract void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration); 
    }

}

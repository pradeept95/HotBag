using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Plugins.PushNotification
{
    public class HotBagFirebasePushNotificationModuel : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "HotBagFirebasePushNotificationModuel"; } 
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

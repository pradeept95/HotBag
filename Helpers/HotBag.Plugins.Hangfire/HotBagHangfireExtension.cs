using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace HotBag
{
    public static class HotBagHangfireExtension
    {
        public static IApplicationBuilder UseHotBagHangfire(this IApplicationBuilder applicationBuilder, IHostingEnvironment env)
        {
            if(HotBagConfiguration.Configurations.ModuleSetting.IsModuleInstalled("HotBagHangfireModuel"))
            {
                applicationBuilder.UseHangfireDashboard("/hangfire");
                applicationBuilder.UseHangfireServer();
            } 
            return applicationBuilder;
        }
    }
}

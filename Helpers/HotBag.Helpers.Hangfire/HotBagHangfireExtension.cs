using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace HotBag.Plugins.Hangfire
{
    public static class HotBagHangfireExtension
    {
        public static IApplicationBuilder UseHotBagHangfire(this IApplicationBuilder applicationBuilder, IHostingEnvironment env)
        {
            applicationBuilder.UseHangfireDashboard("/hangfire");
            applicationBuilder.UseHangfireServer(); 

            return applicationBuilder;
        }
    }
}

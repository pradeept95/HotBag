using Hangfire;
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire.MemoryStorage;
using HotBag.Scheuler;

namespace HotBag.Plugins.Hangfire
{
    public class HotBagHangfireModuel : ApplicationModule
    {
        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        { 
            JobStorage.Current = new MemoryStorage();
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var jobService = serviceProvider.GetService<IJob>();
            jobService.InitializeAllJobs(); 
        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<IJob, Job>();
            serviceCollection.AddHangfire(config =>
            {
                config.UseMemoryStorage();
            });

        }
    }
}

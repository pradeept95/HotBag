using Hangfire;
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire.MemoryStorage;
using HotBag.Scheuler;
using Hangfire.SqlServer;

namespace HotBag.Plugins.Hangfire
{
    public class HotBagHangfireModuel : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "HotBagHangfireModuel"; } 
        }
 
        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string connectionString = configuration["Configuration:EntityFramework:ConnectionString:Default"];
            //set current job storage 
            JobStorage.Current = new SqlServerStorage(connectionString);
            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var jobService = serviceProvider.GetService<IJob>();
            jobService.InitializeAllJobs(); 
        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string connectionString = configuration["Configuration:EntityFramework:ConnectionString:Default"];  // read connection string form appsetting.json
            serviceCollection.AddTransient<IJob, Job>();
            serviceCollection.AddHangfire(config =>
            {
                config.UseSqlServerStorage(connectionString);
            }); 
        }
    }
}

using HotBag.DI;
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core
{
    public static class ApplicationCore
    {
        public static IServiceCollection RegisterHotBagCore(this IServiceCollection services,
            IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetService<IConfiguration>(); 
            services.AddHttpContextAccessor();
            //registering service for later use
            services.AddSingleton(services);
              
            //TODO:: register all dependencies
            //new Bootstrapper(services, serviceProvider);

            //register module,  register all dependencies
            new ModuleBootstrapper(services, serviceProvider);  
            return services; 
        } 
    }
}

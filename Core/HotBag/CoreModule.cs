
using AutoMapper;
using HotBag.AuthConfiguration;
using HotBag.AutoMaper;
using HotBag.DI.Base;
using HotBag.EntityFramework.Context;
using HotBag.Identity.Profiller;
using HotBag.Modules;
using HotBag.OptionConfigurer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag
{
    public class CoreModule : ApplicationModule
    {
        public override string ModuleName
        {
            get {  return "CoreModule"; }

        } 

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper); 
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var applicatonName = HotBagConfiguration.Configurations.ApplicationSettings.ApplicationName;
             
            var nn = HotBagConfiguration.Configurations.ApplicationSettings.ApplicationName;

        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        { 
            serviceCollection.AddScoped<HotBagDbContext>();
            serviceCollection.AddAutoMapper();
            serviceCollection.AddTransient(typeof(HotBag.AutoMaper.IObjectMapper), typeof(HotBagAutoMapper));
            serviceCollection.ConfigureApplicationSettings(configuration);
            AuthConfigurer.Configure(serviceCollection, configuration);

            var applicatonName = HotBagConfiguration.Configurations.ApplicationSettings.ApplicationName;

            HotBagConfiguration.Configurations.ApplicationSettings.SetApplicationSetting("changed at pre initialized");
        }
    }
}

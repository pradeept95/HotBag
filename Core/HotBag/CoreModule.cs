
using AutoMapper;
using HotBag.AuthConfiguration;
using HotBag.AutoMaper;
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

        public override bool IsInstalled  
        {
            get { return true; }

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

        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<HotBagDbContext>();
            serviceCollection.AddAutoMapper();
            serviceCollection.AddTransient(typeof(HotBag.AutoMaper.IObjectMapper), typeof(HotBagAutoMapper));
            serviceCollection.ConfigureApplicationSettings(configuration);
            AuthConfigurer.Configure(serviceCollection, configuration); 
        }
    }
}

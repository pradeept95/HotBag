
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
using System.Linq;
using System.Reflection;

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
           //Auto Mapper Configurations
           var mappingConfig = new MapperConfiguration(mc =>
           {
               mc.ValidateInlineMaps = false;
               mc.AddProfile(new MappingProfile());
           });

            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);

            //Mappings.RegisterMappings();
            serviceCollection.AddSingleton(typeof(HotBag.AutoMaper.IObjectMapper), typeof(HotBagAutoMapper));
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var applicatonName = HotBagConfiguration.Configurations.ApplicationSettings.ApplicationName;
             
            var nn = HotBagConfiguration.Configurations.ApplicationSettings.ApplicationName;

        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        { 
            serviceCollection.AddScoped<HotBagDbContext>();

            var all =
               Assembly
                  .GetEntryAssembly()
                  .GetReferencedAssemblies()
                  .Select(Assembly.Load);

            serviceCollection.AddAutoMapper(all);
             
            serviceCollection.ConfigureApplicationSettings(configuration);
            AuthConfigurer.Configure(serviceCollection, configuration); 
        }
    }
}

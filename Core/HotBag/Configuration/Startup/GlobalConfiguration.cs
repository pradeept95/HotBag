using HotBag.Configuration.Global.Application;
using HotBag.Configuration.Global.ModuleInstallation;
using HotBag.Configuration.Global.ORM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag 
{
   /*
   *  Sealed restricts the inheritance
   */
    public sealed class HotBagConfiguration
    {

        //Lazy initialization
        /*
        * Private property initilized with null
        * ensures that only one instance of the object is created
        * based on the null condition
        */
        private static readonly Lazy<HotBagConfiguration> instance = new Lazy<HotBagConfiguration>(() => new HotBagConfiguration());

        private IServiceProvider serviceProvider;

        /*
       * public property is used to return only one instance of the class
       * leveraging on the private property
       */
        public static HotBagConfiguration Configurations
        {
            get
            {
                //Eager initialization for thread safety
                //if (instance == null)
                //    instance = new ApplicationConfig();
                return instance.Value;
            }
        }

        /// <summary>
        /// Get the applicaton setting
        /// </summary>
        public IApplicationSetting ApplicationSettings { get; private set; }

        public IObjectRelationMapping ObjectRelationMappings { get; private set; }

        public IModuleSetting ModuleSetting { get; private set; }

        /// <summary>
        /// Private constructor for singleton pattern.
        /// </summary>
        private HotBagConfiguration()
        {
            
        }

        /// <summary>
        /// Initialize the global configuration for all over the applicaton
        /// </summary>
        public void Initialize(IServiceCollection serviceCollection)
        {
            this.serviceProvider = serviceCollection.BuildServiceProvider(); 

            this.ApplicationSettings = this.serviceProvider.GetService<IApplicationSetting>();
            this.ObjectRelationMappings = this.serviceProvider.GetService<IObjectRelationMapping>();
            this.ModuleSetting = this.serviceProvider.GetService<IModuleSetting>();
        }
    }
}

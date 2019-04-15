using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag
{
    /*
  *  Sealed restricts the inheritance
  */
    public sealed class IocManager
    {

        //Lazy initialization
        /*
        * Private property initilized with null
        * ensures that only one instance of the object is created
        * based on the null condition
        */
        private static readonly Lazy<IocManager> instance = new Lazy<IocManager>(() => new IocManager());

        private IServiceProvider serviceProvider;
        private IConfiguration configuration;

        /*
       * public property is used to return only one instance of the class
       * leveraging on the private property
       */
        public static IocManager Configurations
        {
            get
            {
                //Eager initialization for thread safety
                //if (instance == null)
                //    instance = new ApplicationConfig();
                return instance.Value;
            }
        }

        public IServiceProvider Manager
        {
            get
            {
                return serviceProvider;

            }  
        }

        public IConfiguration AppConfiguration
        {
            get
            {
                return configuration; 
            }
        }

        /// <summary>
        /// Private constructor for singleton pattern.
        /// </summary>
        private IocManager()
        {

        }

        /// <summary>
        /// Initialize the global configuration for all over the applicaton
        /// </summary>
        public void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            this.serviceProvider = serviceCollection.BuildServiceProvider();
            this.configuration = configuration;
        }
    }
}

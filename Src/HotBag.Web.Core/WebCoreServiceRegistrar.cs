using HotBag.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Web.Core
{
    public class WebCoreServiceRegistrar : IServiceRegistrar
    {
        public void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        { 
          
           // throw new NotImplementedException();
        }

        public void Update(IServiceCollection serviceCollection)
        {
           // throw new NotImplementedException();
        }
    }
}

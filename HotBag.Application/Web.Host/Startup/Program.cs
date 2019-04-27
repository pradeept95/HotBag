using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Web.Host
{
    public class Program
    {
        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            log.Info("Application configuration completed");
            CreateWebHostBuilder(args).Build().Run(); 
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>();
               // .UseStartup<HotBag.Web.Core.Startup>();
    }
}

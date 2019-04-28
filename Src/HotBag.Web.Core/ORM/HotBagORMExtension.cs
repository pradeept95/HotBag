using HotBag.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace HotBag.ORM
{
    public static class HotBagORMExtension
    {
        public static IApplicationBuilder UseHotBagORMOptions(this IApplicationBuilder applicationBuilder, IHostingEnvironment env)
        {
            var allInstalledModule = HotBagConfiguration.Configurations.ModuleSetting.GetAllInstalledModuleInfo();
            if (allInstalledModule.Any(x => x.ModuleName == "MongoDbModule"))
            {
                //use HotBag MongoDb
                applicationBuilder.UseHotBagMondoDb(env);
            }
            else if (allInstalledModule.Any(x => x.ModuleName == "EntityFrameworkCoreModule"))
            {
                //Use HotBag EfCore 
                applicationBuilder.UseHotBagEfCore(env);
            }
            else if (allInstalledModule.Any(x => x.ModuleName == "DapperModule"))
            {
                //use HotBag Dapper
                applicationBuilder.UseHotBagDapper(env);
            } 

            return applicationBuilder;
        }
    }
}

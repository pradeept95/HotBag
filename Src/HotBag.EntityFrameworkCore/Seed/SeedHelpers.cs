using HotBag.EntityFrameworkCore.Context;
using HotBag.EntityFrameworkCore.Seed.Host;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace HotBag.EntityFrameworkCore.Seed
{
    public static class SeedHelpers 
    {
        public async static Task SeedData(IServiceCollection serviceCollection)
        {
            ApplicationDbContext dbContext = serviceCollection.BuildServiceProvider()?.GetService<ApplicationDbContext>();
            if(dbContext != null)
            {
               await SeedHostDatabase.Start(dbContext);
            } 
        }
    }
}

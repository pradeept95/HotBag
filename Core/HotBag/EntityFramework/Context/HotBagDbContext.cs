using HotBag.AppUser;
using HotBag.DI.Base;
using HotBag.Tanents;
using Microsoft.EntityFrameworkCore;

namespace HotBag.EntityFramework.Context
{
    public class HotBagDbContext : DbContext, IScopedDependencies
    {
        public HotBagDbContext(DbContextOptions<HotBagDbContext> options)
          : base(options)
        {
        } 
    }
}

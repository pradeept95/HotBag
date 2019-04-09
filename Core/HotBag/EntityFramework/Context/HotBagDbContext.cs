using HotBag.AppUser;
using HotBag.Tanents;
using Microsoft.EntityFrameworkCore;

namespace HotBag.EntityFramework.Context
{
    public class HotBagDbContext : DbContext
    {
        public HotBagDbContext(DbContextOptions<HotBagDbContext> options)
          : base(options)
        {
        }
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

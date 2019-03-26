using HotBag.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotBag.EntityFrameworkCore.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        public DbSet<TestEntity> TestEntity { get; set; }
        //public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            
        }
    }
}

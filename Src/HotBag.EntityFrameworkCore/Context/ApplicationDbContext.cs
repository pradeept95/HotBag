using HotBag.Core.Entity;
using HotBag.EntityBase;
using HotBag.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace HotBag.EntityFrameworkCore.Context
{
    public class ApplicationDbContext : HotBagDbContext
    {
        public ApplicationDbContext(DbContextOptions<HotBagDbContext> options)
          : base(options)
        {
        }
        public DbSet<TestEntity> TestEntity { get; set; }
        //public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}

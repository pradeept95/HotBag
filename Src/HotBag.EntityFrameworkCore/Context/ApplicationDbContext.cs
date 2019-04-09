using HotBag.AppUser;
using HotBag.Core.Entity;
using HotBag.EntityBase;
using HotBag.EntityFramework.Context;
using HotBag.Tanents;
using Microsoft.EntityFrameworkCore;

namespace HotBag.EntityFrameworkCore.Context
{
    public class ApplicationDbContext : HotBagDbContext
    {
        public ApplicationDbContext(DbContextOptions<HotBagDbContext> options)
          : base(options)
        {
        }

        #region Tanant Related Schema
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<TanentConfiguration> TanentConfiguration { get; set; }

        #endregion

        #region Tanant Related 
        public DbSet<HotBagUser> HotBagUser { get; set; }
        public DbSet<HotBagUserStatusLog> HotBagUserStatusLog { get; set; }
        public DbSet<HotBagPasswordHistoryLog> HotBagPasswordHistoryLog { get; set; }
        public DbSet<HotBagRole> HotBagRole { get; set; }
        public DbSet<HotBagUserRoles> HotBagUserRoles { get; set; }
        public DbSet<HotBagApplicationModule> HotBagApplicationModule { get; set; }
        public DbSet<HotBagApplicationModulePermissionLevel> HotBagApplicationModulePermissionLevel { get; set; }
        public DbSet<HotBagRoleApplicationModule> HotBagRoleApplicationModule { get; set; }

        #endregion

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

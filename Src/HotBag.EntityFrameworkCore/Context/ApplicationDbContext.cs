using HotBag.AppUser;
using HotBag.Core.Entity;
using HotBag.EntityHistory;
using HotBag.Tanents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HotBag.EntityFrameworkCore.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        #region Entity Change History 
        public DbSet<HotBagEntityHistory> HotBagEntityHistory { get; set; } 
        #endregion

        #region Tanant Related Schema
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<TanentConfiguration> TanentConfiguration { get; set; }

        #endregion

        #region User Related 
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

        public override int SaveChanges()
        {
            //var modifiedEntities = ChangeTracker.Entries()
            //    .Where(p => p.State == EntityState.Modified || p.State == EntityState.Added).ToList();
            //var now = DateTime.UtcNow;

            //foreach (var change in modifiedEntities)
            //{
            //    var entityName = change.Entity.GetType().Name;
            //    var primaryKey = GetPrimaryKeyValue(change);

            //    foreach (var prop in change.OriginalValues.PropertyNames)
            //    {
            //        var originalValue = change.OriginalValues[prop].ToString();
            //        var currentValue = change.CurrentValues[prop].ToString();
            //        if (originalValue != currentValue)
            //        {
            //            HotBagEntityHistory changeHistory = new HotBagEntityHistory()
            //            {
            //                EntityName = entityName,
            //                PrimaryKeyValue = primaryKey.ToString(),
            //                PropertyName = prop,
            //                OldValue = originalValue,
            //                NewValue = currentValue,
            //                DateChanged = now
            //            };
            //            HotBagEntityHistory.Add(changeHistory);
            //        }
            //    }
            //}
            return base.SaveChanges();
        }

        //object GetPrimaryKeyValue(DbEntityEntry entry)
        //{
        //    var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
        //    return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        //}
    }

}

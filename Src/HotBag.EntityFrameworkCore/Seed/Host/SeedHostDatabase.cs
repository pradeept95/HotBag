using HotBag.AppUser;
using HotBag.Core.Permissions;
using HotBag.EntityFrameworkCore.Context;
using HotBag.Security.PasswordHasher;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotBag.EntityFrameworkCore.Seed.Host
{
    public static class SeedHostDatabase
    {
        public async static Task Start(ApplicationDbContext dbContext)
        {
            await SeedApplicationModule.Run(dbContext);
            await SeedRoles.Run(dbContext);
            await SeedHostUsers.Run(dbContext);
        }
    }

    public class SeedApplicationModule
    {
        public async static Task Run(ApplicationDbContext dbContext)
        {
            if (dbContext.HotBagApplicationModule.Any())
            {
                return;
            }

            var ApplicationModules = "AppUser, Role, ApplicationModule";
            var modulePermissions = PermissionLevelFactory.GetAllPermissionLevel(new System.Collections.Generic.List<HotBagApplicationModulePermissionLevel>());
            long id = 1;
            foreach (var item in ApplicationModules.Split(","))
            {
                var saveModel = new HotBagApplicationModule
                {
                    Id = id, 
                    ModuleName = item.Trim()
                };

                await dbContext.HotBagApplicationModule.AddAsync(saveModel);

                long modulePermissionId = 1;
                foreach (var permission in modulePermissions)
                {
                    var modulePermissionSaveModel = new HotBagApplicationModulePermissionLevel
                    {
                        Id = modulePermissionId, 
                        HotBagApplicationModuleId = id,
                        PermissionLevel = permission.PermissionLevelName
                    };
                    await dbContext.HotBagApplicationModule.AddAsync(saveModel);
                    modulePermissionId++;
                }
                id++;
            }
            await dbContext.SaveChangesAsync();
        }
    }

    public class SeedRoles
    {
        public async static Task Run(ApplicationDbContext dbContext)
        {
            if (dbContext.HotBagRole.Any())
            {
                return;
            }

            var moduleWithPermission = await (from applicationModule in dbContext.HotBagApplicationModule
                                              join applicationModulePermission in dbContext.HotBagApplicationModulePermissionLevel
                                              on applicationModule.Id equals applicationModulePermission.HotBagApplicationModuleId
                                              select new HotBagRoleApplicationModule
                                              {
                                                  ApplicationModuleId = applicationModule.Id,
                                                  RoleId = 1,
                                                  ApplicationModulePermissionLevelId = applicationModulePermission.Id
                                              }).ToListAsync();

            var roleSaveModule = new HotBagRole
            {
                Id = 1, 
                RoleName = "Administrator"
            };
            await dbContext.HotBagRole.AddAsync(roleSaveModule);
            await dbContext.HotBagRoleApplicationModule.AddRangeAsync(moduleWithPermission); // this assign all the availabe permission

            await dbContext.SaveChangesAsync();
        }
    }

    public class SeedHostUsers
    {
        public async static Task Run(ApplicationDbContext dbContext)
        {
            if (dbContext.HotBagUser.Any())
            {
                return;
            }
            var userSaveModel = new HotBagUser
            {
                Id = Guid.NewGuid(),
                Email = "admin@hotbag.com",
                FirstName = "Admin",
                LastName = "Admin",
                Username = "admin",
                HashedPassword = PasswordHasher.HashPassword("123qwe"),
                Phone = "+977-9860276352",
                Status = UserStatus.Active
            };
            await dbContext.HotBagUser.AddAsync(userSaveModel);

            var userRoleSaveModel = new HotBagUserRoles
            {
                UserId = userSaveModel.Id,
                RoleIdId = 1
            };
            await dbContext.HotBagUserRoles.AddAsync(userRoleSaveModel);
            await dbContext.SaveChangesAsync();
        }
    }
}

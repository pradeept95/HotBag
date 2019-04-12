using HotBag.AppUser;
using HotBag.Core.EntityDto.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotBag.Core.Permissions
{
    public static class PermissionLevelFactory
    {
        public static List<ApplicationModulePermissionLevelItemsDto> GetAllPermissionLevel(List<HotBagApplicationModulePermissionLevel> input)
        { 
            var allPossiblePermissionLevel = new List<ApplicationModulePermissionLevelItemsDto>
            {
                new ApplicationModulePermissionLevelItemsDto
                {
                    Id = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Read)? input.First(x => x.PermissionLevel == ApplicationModulePermissionLevel.Read).Id : 0,
                    PermissionLevelName = ApplicationModulePermissionLevel.Read, 
                    PermissionLevelDisplayName = ApplicationModulePermissionLevel.Read.ToString(),
                    IsAssigned = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Read)
                },
                new ApplicationModulePermissionLevelItemsDto
                {
                    Id = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Create)? input.First(x => x.PermissionLevel == ApplicationModulePermissionLevel.Create).Id : 0,
                    PermissionLevelName = ApplicationModulePermissionLevel.Create,
                    PermissionLevelDisplayName = ApplicationModulePermissionLevel.Create.ToString(),
                    IsAssigned = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Create)
                },
                new ApplicationModulePermissionLevelItemsDto
                {
                    Id = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Edit)? input.First(x => x.PermissionLevel == ApplicationModulePermissionLevel.Edit).Id : 0,
                    PermissionLevelName = ApplicationModulePermissionLevel.Edit,
                    PermissionLevelDisplayName = ApplicationModulePermissionLevel.Edit.ToString(),
                    IsAssigned = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Edit)
                },
                new ApplicationModulePermissionLevelItemsDto
                {
                    Id = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Delete)? input.First(x => x.PermissionLevel == ApplicationModulePermissionLevel.Delete).Id : 0,
                    PermissionLevelName = ApplicationModulePermissionLevel.Delete,
                    PermissionLevelDisplayName = ApplicationModulePermissionLevel.Delete.ToString(),
                    IsAssigned = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Delete)
                },
                new ApplicationModulePermissionLevelItemsDto
                {
                    Id = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Verify)? input.First(x => x.PermissionLevel == ApplicationModulePermissionLevel.Verify).Id : 0,
                    PermissionLevelName = ApplicationModulePermissionLevel.Verify,
                    PermissionLevelDisplayName = ApplicationModulePermissionLevel.Verify.ToString(),
                    IsAssigned = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Verify)
                },
                new ApplicationModulePermissionLevelItemsDto
                {
                    Id = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Download)? input.First(x => x.PermissionLevel == ApplicationModulePermissionLevel.Download).Id : 0,
                    PermissionLevelName = ApplicationModulePermissionLevel.Download,
                    PermissionLevelDisplayName = ApplicationModulePermissionLevel.Download.ToString(),
                    IsAssigned = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Download)
                },
                new ApplicationModulePermissionLevelItemsDto
                {
                    Id = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Print)? input.First(x => x.PermissionLevel == ApplicationModulePermissionLevel.Print).Id : 0,
                    PermissionLevelName = ApplicationModulePermissionLevel.Print,
                    PermissionLevelDisplayName = ApplicationModulePermissionLevel.Print.ToString(),
                    IsAssigned = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Print)
                },
                new ApplicationModulePermissionLevelItemsDto
                {
                    Id = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Import)? input.First(x => x.PermissionLevel == ApplicationModulePermissionLevel.Import).Id : 0,
                    PermissionLevelName = ApplicationModulePermissionLevel.Import,
                    PermissionLevelDisplayName = ApplicationModulePermissionLevel.Import.ToString(),
                    IsAssigned = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Import)
                },
                new ApplicationModulePermissionLevelItemsDto
                {
                    Id = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Export)? input.First(x => x.PermissionLevel == ApplicationModulePermissionLevel.Export).Id : 0,
                    PermissionLevelName = ApplicationModulePermissionLevel.Export,
                    PermissionLevelDisplayName = ApplicationModulePermissionLevel.Export.ToString(),
                    IsAssigned = input.Any(x => x.PermissionLevel == ApplicationModulePermissionLevel.Export)
                }
            };

            return allPossiblePermissionLevel;
        }

    }
}

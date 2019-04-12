using HotBag.AppUser;
using HotBag.AppUserDto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotBag.Core.EntityDto.Authenticate
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Username Or Email is required")]
        public string UsernameOrEmail { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }

    public class ApplicationModuleDto : HotBagApplicationModuleDto
    {
        public ApplicationModuleDto()
        {
            PermissionLevels = new List<ApplicationModulePermissionLevelItemsDto>();
        }
        public List<ApplicationModulePermissionLevelItemsDto> PermissionLevels { get; set; }
    }

    public class ApplicationModulePermissionLevelItemsDto
    {
        public long Id { get; set; }
        public ApplicationModulePermissionLevel PermissionLevelName { get; set; }
        public string PermissionLevelDisplayName { get; set; }
        public bool IsAssigned { get; set; }
    }
}

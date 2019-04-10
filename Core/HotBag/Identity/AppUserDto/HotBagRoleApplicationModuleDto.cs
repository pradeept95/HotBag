using HotBag.AppUser;
using HotBag.AutoMaper.Attributes;

namespace HotBag.AppUserDto
{
    [AutoMapTo(typeof(HotBagRoleApplicationModule))]
    public class HotBagRoleApplicationModuleDto
    {
        public long Id { get; set; } 
        public long RoleId { get; set; } 
        public long ApplicationModuleId { get; set; } 
        public long? ApplicationModulePermissionLevelId { get; set; }  
    } 
}

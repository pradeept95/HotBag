using HotBag.AppUser;
using HotBag.AutoMaper.Attributes;
using System;

namespace HotBag.AppUserDto
{
    [AutoMapTo(typeof(HotBagApplicationModulePermissionLevel))]
    public class HotBagApplicationModulePermissionLevelDto
    {
        public long Id { get; set; }
         
        public long HotBagApplicationModuleId { get; set; } 
        public ApplicationModulePermissionLevel PermissionLevel { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}

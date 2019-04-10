using HotBag.AppUser;
using HotBag.AutoMaper.Attributes;
using System;

namespace HotBag.AppUserDto
{

    [AutoMapTo(typeof(HotBagUserRoles))]
    public class HotBagUserRolesDto
    {
        public long Id { get; set; } 

        public Guid UserId { get; set; } 
        public long RoleIdId { get; set; } 
    }
}

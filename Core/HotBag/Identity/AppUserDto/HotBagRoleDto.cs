using HotBag.AppUser;
using HotBag.AutoMaper.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AppUserDto
{
    [AutoMapTo(typeof(HotBagRole))]
    public class HotBagRoleDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }  
    }
}

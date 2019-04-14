using HotBag.AppUserDto;
using HotBag.AutoMaper.Attributes;
using HotBag.EntityBase;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AppUser
{
    [AutoMap(typeof(HotBagRoleDto))]
    public class HotBagRole : EntityBase<long>
    { 
        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; } 
    }
}

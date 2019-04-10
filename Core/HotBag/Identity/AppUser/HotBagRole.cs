using HotBag.AppUserDto;
using HotBag.AutoMaper.Attributes;
using HotBag.EntityBase;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AppUser
{
    [AutoMap(typeof(HotBagRoleDto))]
    public class HotBagRole : IEFEntityBase<long>
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }  
    }
}

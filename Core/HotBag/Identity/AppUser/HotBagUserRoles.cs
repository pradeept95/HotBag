using HotBag.AppUserDto;
using HotBag.AutoMaper.Attributes;
using HotBag.EntityBase;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.AppUser
{
    [AutoMap(typeof(HotBagUserRolesDto))]
    public class HotBagUserRoles : IEFEntityBase<long>
    {
        public long Id { get; set; }

        [ForeignKey("HotBagUser")]
        public Guid UserId { get; set; }
        public virtual HotBagUser HotBagUser { get; set; }

        [ForeignKey("HotBagRole")]
        public long RoleIdId { get; set; }
        public virtual HotBagRole HotBagRole { get; set; }
    }
}

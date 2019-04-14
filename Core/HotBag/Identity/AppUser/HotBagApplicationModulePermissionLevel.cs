using HotBag.AppUserDto;
using HotBag.AutoMaper.Attributes;
using HotBag.EntityBase;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.AppUser
{
    [AutoMap(typeof(HotBagApplicationModulePermissionLevelDto))]
    public class HotBagApplicationModulePermissionLevel : EntityBase<long>
    { 
        [ForeignKey("HotBagApplicationModule")]
        public long HotBagApplicationModuleId { get; set; }
        public virtual HotBagApplicationModule HotBagApplicationModule { get; set; }

        public ApplicationModulePermissionLevel PermissionLevel { get; set; } 
    }
}

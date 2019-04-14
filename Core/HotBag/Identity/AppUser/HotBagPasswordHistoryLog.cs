using HotBag.AppUserDto;
using HotBag.Autofill.Attribute;
using HotBag.AutoMaper.Attributes;
using HotBag.EntityBase;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.AppUser
{

    [AutoMap(typeof(HotBagPasswordHistoryLogDto))]
    public class HotBagPasswordHistoryLog : EntityBase<long>
    {  
        [ForeignKey("HotBagUser")]
        public Guid UserId { get; set; }
        public virtual HotBagUser HotBagUser { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        [AutoFill(AutoFillProperty.CurrentDate)]
        public DateTime Timestamp { get; set; }
    }
}

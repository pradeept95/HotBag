using HotBag.AutoMaper.Attributes;
using HotBag.EntityBase;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.AppUser
{
    [AutoMap(typeof(HotBagUserStatusLog))]
    public class HotBagUserStatusLog : EntityBase<long>
    { 
        [ForeignKey("HotBagUser")]
        public Guid UserId { get; set; }
        public virtual HotBagUser HotBagUser { get; set; }

        [Required]
        public UserStatus Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

using HotBag.AppUser;
using HotBag.AutoMaper.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AppUserDto
{
    [AutoMapTo(typeof(HotBagUserStatusLog))]
    public class HotBagUserStatusLogDto
    {
        public long Id { get; set; }
         
        public Guid UserId { get; set; }
       
        [Required]
        public UserStatus Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

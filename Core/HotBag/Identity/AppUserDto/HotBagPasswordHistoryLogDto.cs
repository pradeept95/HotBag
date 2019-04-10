using HotBag.AppUser;
using HotBag.AutoMaper.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AppUserDto
{
    [AutoMapTo(typeof(HotBagPasswordHistoryLog))]
    public class HotBagPasswordHistoryLogDto
    {
        public long Id { get; set; }
         
        public Guid UserId { get; set; } 

        [Required]
        public string HashedPassword { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

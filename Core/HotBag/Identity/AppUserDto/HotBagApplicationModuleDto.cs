using HotBag.AppUser;
using HotBag.AutoMaper.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AppUserDto
{
    [AutoMapTo(typeof(HotBagApplicationModule))]
    public class HotBagApplicationModuleDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Application Module Name is Required")]
        public string ModuleName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}

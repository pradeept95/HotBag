using HotBag.AppUserDto;
using HotBag.AutoMaper.Attributes;
using HotBag.EntityBase;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AppUser
{

    [AutoMap(typeof(HotBagApplicationModuleDto))]
    public class HotBagApplicationModule : IEFEntityBase<long>
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Application Module Name is Required")]
        public string ModuleName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}

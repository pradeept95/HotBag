using HotBag.AppUserDto;
using HotBag.AutoMaper.Attributes;
using HotBag.EntityBase;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotBag.AppUser
{

    [AutoMap(typeof(HotBagApplicationModuleDto))]
    public class HotBagApplicationModule : EntityBase<long>
    { 
        [Required(ErrorMessage = "Application Module Name is Required")]
        public string ModuleName { get; set; } 
    }
}

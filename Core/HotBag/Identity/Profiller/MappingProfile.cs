using AutoMapper;
using HotBag.AppUser;
using HotBag.AppUserDto;

namespace HotBag.Identity.Profiller
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<HotBagUser, HotBagUserDto>(); 
            CreateMap<HotBagUserDto, HotBagUser>().ForMember(x =>x.Tanents, opt => opt.Ignore()); 
        }
    }
}

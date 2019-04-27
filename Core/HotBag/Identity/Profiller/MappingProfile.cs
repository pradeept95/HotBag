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
            CreateMap<HotBagUser, HotBagUserDto>()
                 .ForMember(x => x.Password, opt => opt.Ignore()); 
            CreateMap<HotBagUserDto, HotBagUser>().ForMember(x =>x.Tanents, opt => opt.Ignore())
                .ForMember(x => x.HashedPassword, opt => opt.Ignore()); 
        }
    }
}

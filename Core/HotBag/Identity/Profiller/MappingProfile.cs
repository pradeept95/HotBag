using AutoMapper;
using HotBag.AppUser;
using HotBag.AppUserDto;
using HotBag.AutoMaper;
using HotBag.AutoMaper.Attributes;

namespace HotBag.Identity.Profiller
{
    public class MappingProfile : Profile, IProfile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<HotBagUser, HotBagUserDto>()
                 //.ForMember(x => x.Password, opt => opt.Ignore())
                 .IgnoreAllNonExisting();

            CreateMap<HotBagUserDto, HotBagUser>()
                //.ForMember(x => x.HashedPassword, opt => opt.Ignore())
                //.ForMember(x => x.Tanents, opt => opt.Ignore())
                .IgnoreAllNonExisting();
        }
    }
}

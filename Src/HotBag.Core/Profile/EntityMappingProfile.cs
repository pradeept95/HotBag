using AutoMapper;
using HotBag.AutoMaper;
using HotBag.Core.Entity;
using HotBag.Core.EntityDto;

namespace HotBag.Core
{
    public class EntityMappingProfile : Profile, IProfile
    {
        public EntityMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TestEntity, TestEntityDto>();
            CreateMap<TestEntityDto, TestEntity>();
        }
    }
}

using AutoMapper;
using HotBag.Core.Entity;
using HotBag.Core.EntityDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Core
{
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TestEntity, TestEntityDto>();
            CreateMap<TestEntityDto, TestEntity>(); ;
        }
    }
}

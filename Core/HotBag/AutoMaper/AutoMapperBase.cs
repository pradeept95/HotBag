using AutoMapper;
using HotBag.DI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.AutoMaper
{
    public class HotBagAutoMapper : IObjectMapper, ITransientDependencies
    {
        private readonly IMapper _mapper;
        public HotBagAutoMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            TDestination destinationObj = _mapper.Map<TDestination>(source);
            return destinationObj;
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            TDestination destinationObj = _mapper.Map(source, destination);
            return destinationObj;
        }
    }
}

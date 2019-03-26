using AutoMapper;
using HotBag.AutoMaper.Extensions;
using HotBag.Extensions;
using System;

namespace HotBag.AutoMaper.Attributes
{
    public class AutoMapToAttribute : AutoMapAttributeBase
    {
        public MemberList MemberList { get; set; } = MemberList.Source;

        public AutoMapToAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {

        }

        public AutoMapToAttribute(MemberList memberList, params Type[] targetTypes)
            : this(targetTypes)
        {
            MemberList = memberList;
        }

        public override void CreateMap(IMapperConfigurationExpression configuration, Type type)
        {
            if (TargetTypes.IsNullOrEmpty())
            {
                return;
            }

            configuration.CreateAutoAttributeMaps(type, TargetTypes, MemberList);
        }
    }
}

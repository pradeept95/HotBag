using System;

namespace HotBag.Web.Core.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        public GeneratedControllerAttribute(string route)
        {
            Route = route;
        }

        public string Route { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerDtoAttribute : Attribute
    {
        public Type EntityDtoType;
        public Type PrimaryKeyType;
        public GeneratedControllerDtoAttribute(Type typeOfEntityDto, Type typeOfPrimaryKey)
        {
            EntityDtoType = typeOfEntityDto;
            PrimaryKeyType = typeOfPrimaryKey;
        } 
    }
}

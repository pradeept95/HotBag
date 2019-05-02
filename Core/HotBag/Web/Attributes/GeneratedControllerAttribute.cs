using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace HotBag.Web.Core.Web.Attributes
{
    //[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    //public class GeneratedControllerAttribute : Attribute
    //{
    //    public GeneratedControllerAttribute(string route)
    //    {
    //        Route = route;
    //    }

    //    public string Route { get; set; }
    //}

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        public Type EntityDtoType;
        public Type PrimaryKeyType;
        public GeneratedControllerAttribute(Type typeOfEntityDto, Type typeOfPrimaryKey)
        {
            EntityDtoType = typeOfEntityDto;
            PrimaryKeyType = typeOfPrimaryKey;
        } 
    } 
}

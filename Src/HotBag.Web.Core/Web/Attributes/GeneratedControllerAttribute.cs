using HotBag.Web.GenericBase;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
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

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GenericControllerNameAttribute : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.GetGenericTypeDefinition() == typeof(GenericBaseController<,,>))
            {
                var entityType = controller.ControllerType.GenericTypeArguments[0];
                controller.ControllerName = entityType.Name;
            }
        }
    }
}

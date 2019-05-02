using HotBag.Web.Core.Web.Attributes;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HotBag.Web
{
    public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            //var currentAssembly = typeof(GenericTypeControllerFeatureProvider).Assembly;
            
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);
            var allAssembly = runtimeAssemblyNames
                .Select(Assembly.Load)
                .Where(x => x.FullName.Contains("HotBag"));

            foreach (var assembly in allAssembly)
            {
                var candidates = assembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());

                foreach (var candidate in candidates)
                {
                    var dto = candidate.GetCustomAttribute<GeneratedControllerAttribute>();
                    if (dto == null)
                    {
                        continue;
                    }
                    var genController = typeof(HotBag.Web.GenericBase.GenericBaseController<,,>).MakeGenericType(candidate, dto.EntityDtoType, dto.PrimaryKeyType).GetTypeInfo();
                    feature.Controllers.Add(genController);
                }
            } 
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public class GenericControllerNameAttribute : Attribute, IControllerModelConvention
        {
            public void Apply(ControllerModel controller)
            {
                if (controller.ControllerType.GetGenericTypeDefinition() == typeof(HotBag.Web.GenericBase.GenericBaseController<,,>))
                {
                    var entityType = controller.ControllerType.GenericTypeArguments[0];
                    controller.ControllerName = entityType.Name;
                }
            }
        }
    }
}

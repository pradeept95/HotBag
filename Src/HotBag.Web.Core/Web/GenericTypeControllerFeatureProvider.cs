using HotBag.Web.Core.Web.Attributes;
using HotBag.Web.GenericBase;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HotBag.Web.Core.Web
{
    public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(GenericTypeControllerFeatureProvider).Assembly;
            var candidates = currentAssembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());

            foreach (var candidate in candidates)
            {
                var dto = candidate.GetCustomAttribute<GeneratedControllerDtoAttribute>();
                if(dto == null)
                {
                    continue;
                }
                var genController = typeof(GenericBaseController<,,>).MakeGenericType(candidate, dto.EntityDtoType, dto.PrimaryKeyType).GetTypeInfo(); 
                feature.Controllers.Add(genController);
            }
        }
    }
}

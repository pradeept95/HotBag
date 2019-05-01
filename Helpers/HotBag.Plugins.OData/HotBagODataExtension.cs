using HotBag.Core.Entity;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Plugins.OData
{
    public static class HotBagODataExtension
    {
        public static IRouteBuilder UseHotBagODataRoute(this IRouteBuilder routerBuilder)
        { 
              return  routerBuilder
                .Filter()
                .Expand()
                .OrderBy()
                .Count()
                .MaxTop(10)  
                .Select(); 
        }
    }
}

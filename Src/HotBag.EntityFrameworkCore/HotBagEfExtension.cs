using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.EntityFrameworkCore
{
    public static class HotBagEfExtension
    {
        public static IApplicationBuilder UseHotBagEfCore(this IApplicationBuilder applicationBuilder, IHostingEnvironment env)
        { 
            return applicationBuilder;
        }
    }
}

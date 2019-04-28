using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag
{
    public static class HotBagEfExtension
    {
        public static IApplicationBuilder UseHotBagEfCore(this IApplicationBuilder applicationBuilder, IHostingEnvironment env)
        {
            if(HotBagConfiguration.Configurations.ObjectRelationMappings.CurrentSelectedORM != Data.DatabaseORM.EntityFrameworkCore)
                HotBagConfiguration.Configurations.ObjectRelationMappings.SetNewORM(Data.DatabaseORM.EntityFrameworkCore);
            return applicationBuilder;
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.EntityFrameworkCore
{
    public static class HotBagEfExtension
    {
        public static IApplicationBuilder UseHotBagDapper(this IApplicationBuilder applicationBuilder, IHostingEnvironment env)
        {
            if(HotBagConfiguration.Configurations.ObjectRelationMappings.CurrentSelectedORM != Data.DatabaseORM.Dapper)
                HotBagConfiguration.Configurations.ObjectRelationMappings.SetNewORM(Data.DatabaseORM.Dapper);
            return applicationBuilder;
        }
    }
}

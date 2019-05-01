using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace HotBag
{
    public static class HotBagSwaggerExtension
    {
        public static IApplicationBuilder UseHotBagSwagger(this IApplicationBuilder applicationBuilder)
        {
            if (HotBagConfiguration.Configurations.ModuleSetting.IsModuleInstalled("HotBagSwaggerModuel"))
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                applicationBuilder.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                // specifying the Swagger JSON endpoint.
                applicationBuilder.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"HotBag Enterprise Application Framework");
                });
            } 
            return applicationBuilder;
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Reflection;

namespace HotBag.Plugins.GraphQl
{
    public static class HotBagGraphQLExtension
    {
        public static IApplicationBuilder UseHotGraphQL(this IApplicationBuilder applicationBuilder)
        {
            if (HotBagConfiguration.Configurations.ModuleSetting.IsModuleInstalled("GraphQLModule"))
            {
                applicationBuilder.UseFileServer(
                    new FileServerOptions
                    {
                        RequestPath = "/graphql/playground",
                        FileProvider = new PhysicalFileProvider(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "PlayGround"))
                    });
            }
            return applicationBuilder;
        }
    }
}

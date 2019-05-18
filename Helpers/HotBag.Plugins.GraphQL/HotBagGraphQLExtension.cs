using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using HotBag.Plugins.GraphQL.Middleware;
using Microsoft.AspNetCore.Builder;

namespace HotBag.Plugins.GraphQl
{
    public static class HotBagGraphQLExtension
    {
        public static IApplicationBuilder UseHotGraphQL<TSchema>(this IApplicationBuilder applicationBuilder)
            where TSchema : ISchema
        {
            if (HotBagConfiguration.Configurations.ModuleSetting.IsModuleInstalled("GraphQLModule"))
            {
                //applicationBuilder.UseFileServer(
                //    new FileServerOptions
                //    {
                //        RequestPath = "/graphql/playground",
                //        FileProvider = new PhysicalFileProvider(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "PlayGround"))
                //    });
                applicationBuilder.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
                applicationBuilder.UseGraphQL<TSchema>();
                //applicationBuilder.UseMiddleware<GraphQLMiddleware<TSchema>>();
            }
            return applicationBuilder;
        }
    } 
}

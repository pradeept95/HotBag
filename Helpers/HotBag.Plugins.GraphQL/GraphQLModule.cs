using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using HotBag.Modules;
using HotBag.Plugins.GraphQL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Plugins.GraphQl
{
    public class GraphQLModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "GraphQLModule"; } 
        } 

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
           
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        { 

        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<HotBagQueryType>();
            //serviceCollection.AddScoped<HotBagApplicationType>();

            serviceCollection.AddScoped<HotBagMutationType>();
            serviceCollection.AddScoped<HotBagAppSchema>();

            serviceCollection.AddTransient<IDependencyResolver>(
                serviceProvider => {
                        return new FuncDependencyResolver(serviceProvider.GetRequiredService);
                });

            serviceCollection.AddGraphQL(o => { o.ExposeExceptions = true; })
                 .AddGraphTypes(ServiceLifetime.Scoped);

            //serviceCollection.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            //serviceCollection.AddSingleton<IDocumentWriter, DocumentWriter>(); 
        }
    } 
}

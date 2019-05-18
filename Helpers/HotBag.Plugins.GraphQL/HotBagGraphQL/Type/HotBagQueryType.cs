using GraphQL.Types;

namespace HotBag.Plugins.GraphQL
{
    public class HotBagQueryType : ObjectGraphType 
    {
        public HotBagQueryType()
        {
            Name = "Query";

            Field<HotBagApplicationType>(
                name: "application",
                resolve: context =>
                {
                    return new HotBagApplication
                    {
                        Name = "HotBag Enterprise : An Asp.Net  Boilerplate Framework",
                        Version = "v1.0.3"
                    };
                });
        }
    }

    public class HotBagMutationType : ObjectGraphType
    {
        public HotBagMutationType()
        {
            Name = "Mutation";

            Field<StringGraphType>(
                name: "addMessage",
                resolve: context => "Hello from HotBag Enterprise asp.net boilerplate framework"
                );
        }
    }

    public class HotBagApplication
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public class HotBagApplicationType : ObjectGraphType<HotBagApplication> 
    {
        public HotBagApplicationType()
        {
            Field(x => x.Name).Description("Name Of An Application.");
            Field(x => x.Version).Description("Current Version of an Application.");
        }
    }
}

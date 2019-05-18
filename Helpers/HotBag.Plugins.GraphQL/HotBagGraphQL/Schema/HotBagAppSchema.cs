using GraphQL;
using GraphQL.Types;

namespace HotBag.Plugins.GraphQL
{
    public class HotBagAppSchema : Schema
    {
        public HotBagAppSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<HotBagQueryType>();
            Mutation = resolver.Resolve<HotBagMutationType>();
        }
    }
}

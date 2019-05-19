using GraphQL.Types;

namespace HotBag.Plugins.GraphQL
{
    public class HotBagApplicationType : ObjectGraphType<HotBagApplication> 
    {
        public HotBagApplicationType()
        {
            Field(x => x.Name).Description("Name Of An Application.");
            Field(x => x.Version).Description("Current Version of an Application.");
        }
    }
}

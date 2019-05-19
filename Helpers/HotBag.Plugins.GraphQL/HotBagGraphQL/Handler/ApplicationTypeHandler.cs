using GraphQL.Types;
using HotBag.DI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Plugins.GraphQL.HotBagGraphQL.Handler
{
    public class ApplicationTypeHandler : ObjectGraphType, IApplicationTypeHandler, ITransientDependencies
    {
        public ApplicationTypeHandler()
        {
            Name = "Query"; 
        }
    }

    public interface IApplicationTypeHandler
    {

    }
}

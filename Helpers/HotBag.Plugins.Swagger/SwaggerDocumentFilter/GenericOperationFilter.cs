using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace HotBag.SB.Helpers
{
    public class GenericOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
            {
                var baseType = controllerDescriptor.ControllerTypeInfo.BaseType?.GetTypeInfo();
                // Get type and see if its a generic controller with a single type parameter
                if (baseType == null || (!baseType.IsGenericType && baseType.GenericTypeParameters.Length == 1))
                    return;

                if (context.ApiDescription.HttpMethod == "GET" && !operation.Responses.ContainsKey("200"))
                {
                    var typeParam = baseType.GenericTypeParameters[0];

                    // Get the schema of the generic type. In case it's not there, you will have to create a schema for that model
                    // yourself, because Swagger may not have added it, because the type was not declared on any of the models
                    string typeParamFriendlyId = typeParam.FriendlyId();

                    if (!context.SchemaRegistry.Definitions.TryGetValue(typeParamFriendlyId, out Schema typeParamSchema))
                    {
                        // Schema doesn't exist, you need to create it yourself, i.e. add properties for each property of your model.
                        // See OpenAPI/Swagger Specifications
                        typeParamSchema = context.SchemaRegistry.GetOrRegister(typeParam);

                        // add properties here, without it you won't have a model description for this type
                    }

                    // for any get operation for which no 200 response exist yet in the document
                    operation.Responses.Add("200", new Response
                    {
                        Description = "Success",
                        Schema = new Schema { Ref = typeParamFriendlyId }
                    });
                }
            }
        }
    }
}


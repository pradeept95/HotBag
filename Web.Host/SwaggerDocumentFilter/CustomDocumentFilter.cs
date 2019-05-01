using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; 
using System.Text;
using Microsoft.AspNet.OData;

namespace HotBag.SB.Helpers
{
    public class CustomDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            Assembly assembly = typeof(ODataController).Assembly;
            var thisAssemblyTypes = Assembly.GetExecutingAssembly().GetTypes().ToList();
            var odatacontrollers = thisAssemblyTypes.Where(t => t.BaseType == typeof(Microsoft.AspNet.OData.ODataController)).ToList();
            var odatamethods = new[] { "Get", "Put", "Post", "Delete", "Option" };

            foreach (var odataContoller in odatacontrollers)  // this the OData controllers in the API
            {
                var methods = odataContoller.GetMethods().Where(a => odatamethods.Contains(a.Name)).ToList();
                if (!methods.Any())
                    continue; // next controller 

                foreach (var method in methods)  // this is all of the methods in controller (e.g. GET, POST, PUT, etc)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("/" + method.Name + "(");
                    List<String> listParams = new List<String>();
                    var parameterInfo = method.GetParameters();
                    foreach (ParameterInfo pi in parameterInfo)
                    {
                        listParams.Add(pi.ParameterType + " " + pi.Name);
                    }
                    sb.Append(String.Join(", ", listParams.ToArray()));
                    sb.Append(")");
                    var path = "/" + "api" + "/" + odataContoller.Name.Replace("Controller", "") + sb.ToString();
                    var odataPathItem = new PathItem();
                    var op = new Operation();

                    // The odata methods will be listed under a heading called OData in the swagger doc
                    op.Tags = new List<string> { "OData" };
                    op.OperationId = "OData_" + odataContoller.Name.Replace("Controller", "");

                    // This hard-coded for now, set it to use XML comments if you want
                    op.Summary = "Summary about method / data";
                    op.Description = "Description / options for the call.";

                    op.Consumes = new List<string>();
                    op.Produces = new List<string> { "application/atom+xml", "application/json", "text/json", "application/xml", "text/xml" };
                    op.Deprecated = false;

                    var response = new Response() { Description = "OK" };
                    response.Schema = new Schema { Type = "array", Items = context.SchemaRegistry.GetOrRegister(method.ReturnType) };
                    op.Responses = new Dictionary<string, Response> { { "200", response } };

                    var security = GetSecurityForOperation(odataContoller);
                    if (security != null)
                        op.Security = new List<IDictionary<string, IEnumerable<string>>> { security };

                    odataPathItem.Get = op;

                    try
                    {
                        swaggerDoc.Paths.Add(path, odataPathItem);
                    }
                    catch { }
                }
            }
        }

        private Dictionary<string, IEnumerable<string>> GetSecurityForOperation(MemberInfo odataContoller)
        {
            Dictionary<string, IEnumerable<string>> securityEntries = null;
            if (odataContoller.GetCustomAttribute(typeof(Microsoft.AspNetCore.Authorization.AuthorizeAttribute)) != null)
            {
                securityEntries = new Dictionary<string, IEnumerable<string>> { { "oauth2", new[] { "actioncenter" } } };
            }
            return securityEntries;
        }
    }
}


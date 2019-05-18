using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HotBag.Plugins.GraphQL.Middleware
{
    public class GraphQLMiddleware<TSchema> where TSchema : ISchema
    {
        private readonly RequestDelegate _next;
        private TSchema Schema { get; }

        private readonly IDocumentExecuter _executer;
        private readonly IDocumentWriter _writter;

        public GraphQLMiddleware(
            RequestDelegate next,
            TSchema schema,
            IDocumentExecuter executer,
            IDocumentWriter writter
            )
        {
            _next = next;
            Schema = schema;
            _executer = executer;
            _writter = writter;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (
                context.Request.Method.ToUpper() != "POST"
                && context.Request.Path != "/graphql"
                )
            {
                await _next(context);
                return;
            }

            var request = Deserialize<GraphQlRequest>(context.Request.Body);

            var result = await _executer.ExecuteAsync(new ExecutionOptions
            {
                Schema = Schema,
                Query = request.Query,
                OperationName = request.OperationName,
                Inputs = request.Veriables.ToInputs()
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)(result.Errors?.Any() == true ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
            await context.Response.WriteAsync(_writter.Write(result));
        }

        private T Deserialize<T>(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                using (var jsonReader = new JsonTextReader(reader))
                {
                    return new JsonSerializer().Deserialize<T>(jsonReader);
                }
            }
        }
    }
}

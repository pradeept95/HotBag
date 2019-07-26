using GraphQL.Types;
using HotBag.Core.EntityDto;
using HotBag.EntityBase;
using HotBag.Plugins.GraphQL.HotBagGraphQL.Handler;
using HotBag.ResultWrapper.ResponseModel;
using HotBag.Services.Providers;

namespace HotBag.Plugins.GraphQL
{
    public class HotBagQueryType : ObjectGraphType
    {
        public HotBagQueryType(
            ITestService testService
            )
        {
            Name = "Query";


            Field<HotBagApplicationType>(
             name: "application",
             resolve: context =>
             {
                 return new HotBagApplication
                 {
                     Name = "HotBag Enterprise : An Asp.Net Core Boilerplate Application Framework",
                     Version = "v1.0.0.3"
                 };

             });


            Field<ListResultDtoType<TestEntityDto, TestEntityDtoType>>(
              name: "test",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<QueryRequestType>> { Name = "query" }),
              resolve: context =>
              {
                  var query = context.GetArgument<QueryRequest>("query");
                  return testService.GetAll(query.Query.SearchText);
              });

            //Field<ListResultDtoType<TestEntityDto, TestEntityDtoType>>(
            // name: "test:getAllPaged",
            // arguments: new QueryArguments(
            //     new QueryArgument<StringGraphType> { Name = "skip" },
            //     new QueryArgument<StringGraphType> { Name = "maxResultCount" },
            //     new QueryArgument<StringGraphType> { Name = "searchText" }
            // ),
            // resolve: context =>
            // {
            //     var searchText = context.GetArgument<string>("searchText");
            //     var skip = context.GetArgument<int>("searchText");
            //     var maxResultCount = context.GetArgument<int>("searchText");

            //     return testService.GetAllPaged(skip, maxResultCount, searchText);
            // });
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

    public class ListResultDtoType<TEntity, TEntityType> : ObjectGraphType<ListResultDto<TEntity>>
        where TEntityType : class, IGraphType
        //where TEntity : class, IEntityBaseDto
    {
        public ListResultDtoType()
        {
            Field<ListGraphType<TEntityType>>("Data", "All the data field inside the schema.");
            Field(x => x.Summary).Description("test Name Of An Application.");
        }
    }

    public class TestEntityDtoType : ObjectGraphType<TestEntityDto>
    {
        public TestEntityDtoType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the account object.");
            Field(x => x.TestName).Description("test Name Of An Application.");
            Field(x => x.TestProp1).Description("TestProp1.");
            Field(x => x.TestProp2).Description("TestProp2.");
            Field(x => x.TestProp3).Description("TestProp3.");
        }
    }


    public class QueryRequest
    {
        public RequestModeEnum Mode { get; set; }
        public RequestModel Query { get; set; }
    }

    public class QueryRequestType : InputObjectGraphType<QueryRequest>
    {
        public QueryRequestType()
        {
            Field<NonNullGraphType<RequestModeEnumType>>("mode");
            Field<NonNullGraphType<RequestModelType>>("query");  
        }
    } 

    public enum RequestModeEnum
    {
        get = 1,
        getAll,
        getAllPaged,
        getCount
    }

    public class RequestModeEnumType : EnumerationGraphType<RequestModeEnum>
    {
        public RequestModeEnumType()
        { 
        }
    }

    public class RequestModel
    {
        public int Skip { get; set; }
        public int MaxResultCount { get; set; }
        public string SearchText { get; set; }
    }

    public class RequestModelType : InputObjectGraphType<RequestModel>
    {
        public RequestModelType()
        { 
            Field(x => x.Skip).Description("Total record to be skipped/ignore");
            Field(x => x.MaxResultCount).Description("Page Size.");
            Field(x => x.SearchText).Description("Search into the result");
        }
    }

}

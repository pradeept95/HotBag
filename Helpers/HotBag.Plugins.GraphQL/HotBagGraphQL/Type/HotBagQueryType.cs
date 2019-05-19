using GraphQL.Types;
using HotBag.Core.EntityDto;
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


            Field<ListResultDtoType<TestEntityDtoType>>(
              name: "test",
              arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "searchText" }),
              resolve: context =>
              {
                  var searchText = context.GetArgument<string>("searchText");
                  return testService.GetAll(searchText);
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
     
    public class ListResultDtoType<T> : ObjectGraphType<ListResultDto<T>> where T : class, IGraphType
    {
        public ListResultDtoType()
        {
            Field<ListGraphType<T>>("Data", "All the data field inside the schema."); 
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
}

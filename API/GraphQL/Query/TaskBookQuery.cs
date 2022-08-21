using API.Models;
using GraphQL;
using GraphQL.Types;
using API.Interfaces;
using API.GraphQL.Types;
using API.Providers;

namespace API.GraphQL.Query
{
    public class TaskBookQuery : ObjectGraphType
    {

        public TaskBookQuery(ITaskBookProviderDB providerDB)
        {
            Field<ListGraphType<TaskModelGraphType>>()
                .Name("getAll")
                .Argument<StringGraphType>("sortParam")
                .Resolve(context => {
                    var sortParam = context.GetArgument<string>("sortParam");
                    return providerDB.GetAllTasks(sortParam);
                });

            Field<TaskModelGraphType>()
                .Name("getById")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return providerDB.GetTaskByID(id);
                });
        }
    }
}

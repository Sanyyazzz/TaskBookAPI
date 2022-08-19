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
                .Resolve(context => providerDB.GetAllTasks());

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

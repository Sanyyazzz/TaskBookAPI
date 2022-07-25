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
                .Name("getAllTask")
                .Resolve(context => providerDB.GetAllTasks());

            Field<ListGraphType<CategoryModelGraphType>>()
                .Name("getAllCategory")
                .Resolve(context => providerDB.GetAllCategories());
        }
    }
}

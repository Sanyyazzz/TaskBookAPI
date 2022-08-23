using GraphQL.Types;
using API.GraphQL.Mutation;

namespace API.GraphQL
{
    public class RootMutation : ObjectGraphType
    {

        public RootMutation()
        {
            Field<TaskBookMutation>()
                .Name("task")
                .Resolve(context => new { });

            Field<CategoryMutation>()
                .Name("category")
                .Resolve(context => new { });

            Field<ServiceMutation>()
                .Name("service")
                .Resolve(context => new { });
        }
    }
}

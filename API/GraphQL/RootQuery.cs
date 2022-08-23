using GraphQL.Types;
using API.GraphQL.Types;
using API.GraphQL.Query;

namespace API.GraphQL
{
    public class RootQuery : ObjectGraphType
    {

        public RootQuery()
        {
            Field<TaskBookQuery>()
                .Name("task")
                .Resolve(context => new { });

            Field<CategoryQuery>()
                .Name("category")
                .Resolve(context => new { });
        }
    }
}

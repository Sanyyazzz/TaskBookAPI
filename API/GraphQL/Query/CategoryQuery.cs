using API.Models;
using GraphQL;
using GraphQL.Types;
using API.Interfaces;
using API.GraphQL.Types;
using API.Providers;

namespace API.GraphQL.Query
{
    public class CategoryQuery : ObjectGraphType
    {

        public CategoryQuery(ITaskBookProviderDB providerDB)
        {
            Field<ListGraphType<CategoryModelGraphType>>()
                .Name("getAll")
                .Resolve(context => providerDB.GetAllCategories());

            Field<CategoryModelGraphType>()
                .Name("getById")
                .Argument<IntGraphType>("id")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return providerDB.GetCategoryByID(id);
                });
        }
    }
}

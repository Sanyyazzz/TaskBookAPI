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

        public CategoryQuery(IServiceHandler providerDB)
        {
            Field<ListGraphType<CategoryModelGraphType>>()
                .Name("getAll")
                .Resolve(context => providerDB.GetProvider().GetAllCategories());

            Field<CategoryModelGraphType>()
                .Name("getById")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return providerDB.GetProvider().GetCategoryByID(id);
                });
        }
    }
}

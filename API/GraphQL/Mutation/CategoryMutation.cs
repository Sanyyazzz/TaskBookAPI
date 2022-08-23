using GraphQL;
using GraphQL.Types;
using API.GraphQL.Types;
using API.Models;
using API.Providers;
using API.Interfaces;

namespace API.GraphQL.Mutation
{
    public class CategoryMutation : ObjectGraphType
    {
        public CategoryMutation(IServiceHandler providerDB)
        {
            Field<CategoryModelGraphType>()
                .Name("addCategory")
                .Argument<NonNullGraphType<CategoryInputGraphType>>("category")
                .Resolve(context =>
                {
                    var category = context.GetArgument<CategoryInputModel>("category");
                    var id = providerDB.GetProvider().AddCategory(category);
                    return providerDB.GetProvider().GetCategoryByID(id);
                });

            Field<IntGraphType>()
                .Name("deleteCategory")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return providerDB.GetProvider().DeleteCategory(id);
                });

            Field<CategoryModelGraphType>()
                .Name("editCategory")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Argument<NonNullGraphType<CategoryInputGraphType>>("category")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    var category = context.GetArgument<CategoryInputModel>("category");
                    providerDB.GetProvider().EditCategory(id, category);
                    return providerDB.GetProvider().GetCategoryByID(id);
                });
        }
    }
}

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
        public CategoryMutation(ITaskBookProviderDB providerDB)
        {
            Field<CategoryModelGraphType>()
                .Name("addCategory")
                .Argument<NonNullGraphType<CategoryInputGraphType>>("category")
                .Resolve(context =>
                {
                    var category = context.GetArgument<CategoryInputModel>("category");
                    var id = providerDB.AddCategory(category);
                    return providerDB.GetCategoryByID(id);
                });

            Field<IntGraphType>()
                .Name("deleteCategory")
                .Argument<IntGraphType>("id")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return providerDB.DeleteCategory(id);
                });

            Field<CategoryModelGraphType>()
                .Name("editCategory")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Argument<NonNullGraphType<CategoryInputGraphType>>("category")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    var category = context.GetArgument<CategoryInputModel>("category");
                    providerDB.EditCategory(id, category);
                    return providerDB.GetCategoryByID(id);
                });
        }
    }
}

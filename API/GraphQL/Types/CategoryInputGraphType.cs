using API.Models;
using GraphQL;
using GraphQL.Types;

namespace API.GraphQL.Types
{
    public class CategoryInputGraphType : InputObjectGraphType<CategoryInputModel>
    {
        public CategoryInputGraphType()
        {
            Field<StringGraphType>().Name("category").Resolve(context => context.Source.Category);
        }
    }
}

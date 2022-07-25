using API.Models;
using GraphQL.Types;

namespace API.GraphQL.Types
{ 
    public class CategoryModelGraphType : ObjectGraphType<CategoryModel>
    {
        public CategoryModelGraphType()
        {
            Field<NonNullGraphType<IntGraphType>>().Name("id").Resolve(context => context.Source.ID);
            Field<NonNullGraphType<StringGraphType>>().Name("category").Resolve(context => context.Source.Category);            
        }
        
    }
}

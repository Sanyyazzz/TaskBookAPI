using GraphQL.Types;
using API.GraphQL.Query;
using API.GraphQL.Mutation;

namespace API.GraphQL
{
    public class TaskBookSchema : Schema, ISchema
    {
        public TaskBookSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<RootMutation>();
        }
    }
}
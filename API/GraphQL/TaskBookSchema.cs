using GraphQL.Types;
using API.GraphQL.Query;

namespace API.GraphQL
{
    public class TaskBookSchema : Schema, ISchema
    {
        public TaskBookSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<TaskBookQuery>();
        }
    }
}
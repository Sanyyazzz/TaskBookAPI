using API.Models;
using GraphQL.Types;


namespace API.GraphQL.Types
{
    public class TaskModelGraphType : ObjectGraphType<TaskModel>
    {
        public TaskModelGraphType()
        {
            Field<NonNullGraphType<IntGraphType>>().Name("id").Resolve(context => context.Source.ID);
            Field<NonNullGraphType<StringGraphType>>().Name("taskDesc").Resolve(context => context.Source.TaskDesc);
            Field<StringGraphType>().Name("category").Resolve(context => context.Source.Category);
            Field<DateTimeGraphType>().Name("deadLine").Resolve(context => context.Source.DeadLine);
            Field<BooleanGraphType>().Name("important").Resolve(context => context.Source.Important);
            Field<BooleanGraphType>().Name("completed").Resolve(context => context.Source.Completed);
        }
    }
}

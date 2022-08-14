using API.Models;
using GraphQL.Types;


namespace API.GraphQL.Types
{
    public class TaskInputModelGraphType : InputObjectGraphType<TaskInputModel>
    {
        public TaskInputModelGraphType()
        {
            Field<NonNullGraphType<StringGraphType>>().Name("taskDesc").Resolve(context => context.Source.TaskDesc);
            Field<IntGraphType>().Name("categoryID").Resolve(context => context.Source.CategoryID);
            Field<DateTimeGraphType>().Name("deadLine").Resolve(context => context.Source.DeadLine);
            Field<BooleanGraphType>().Name("important").Resolve(context => context.Source.Important);
            Field<BooleanGraphType>().Name("completed").Resolve(context => context.Source.Completed);
        }
    }
}

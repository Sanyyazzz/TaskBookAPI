using GraphQL;
using GraphQL.Types;
using API.GraphQL.Types;
using API.Models;
using API.Providers;
using API.Interfaces;

namespace API.GraphQL.Mutation
{
    public class TaskBookMutation : ObjectGraphType
    {
        public TaskBookMutation(ITaskBookProviderDB providerDB)
        {
            Field<TaskModelGraphType>()
                .Name("addTask")
                .Argument<NonNullGraphType<TaskInputModelGraphType>>("task")
                .Resolve( context => 
                {
                    var task = context.GetArgument<TaskInputModel>("task");
                    var id = providerDB.AddTask(task);
                    return providerDB.GetTaskByID(id);
                });

            Field<IntGraphType>()
                .Name("deleteTask")
                .Argument<IntGraphType>("id")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return providerDB.DeleteTask(id);
                });

            Field<TaskModelGraphType>()
                .Name("editTask")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Argument<NonNullGraphType<TaskInputModelGraphType>>("task")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    var task = context.GetArgument<TaskInputModel>("task");
                    providerDB.EditTask(id, task);
                    return providerDB.GetTaskByID(id);
                });

            Field<TaskModelGraphType>()
                .Name("completeTask")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    providerDB.CompleteTask(id);
                    return providerDB.GetTaskByID(id);
                });
        }        
    }
}

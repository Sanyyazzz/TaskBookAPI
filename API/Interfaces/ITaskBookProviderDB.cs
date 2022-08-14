using API.Models;

namespace API.Interfaces
{
    public interface ITaskBookProviderDB
    {
        List<TaskModel> GetAllTasks();
        int AddTask(TaskInputModel taskModel);
        int DeleteTask(int id);
        int CompleteTask(int id);
        int EditTask(int id, TaskInputModel task);
        TaskModel GetTaskByID(int id);

        List<CategoryModel> GetAllCategories();
        int AddCategory(CategoryInputModel taskModel);
        int DeleteCategory(int id);
        int EditCategory(int id, CategoryInputModel task);
        CategoryModel GetCategoryByID(int id);
    }
}

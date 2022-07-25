using API.Models;

namespace API.Interfaces
{
    public interface ITaskBookProviderDB
    {
        List<TaskModel> GetAllTasks();
        List<CategoryModel> GetAllCategories();
    }
}

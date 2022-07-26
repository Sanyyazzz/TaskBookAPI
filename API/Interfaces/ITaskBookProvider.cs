﻿using API.Models;

namespace API.Interfaces
{
    public interface ITaskBookProvider
    {
        IEnumerable<TaskModel> GetAllTasks(string? sortParameter);
        int AddTask(TaskInputModel taskModel);
        int DeleteTask(int id);
        int CompleteTask(int id);
        int EditTask(int id, TaskInputModel task);
        TaskModel GetTaskByID(int id);

        IEnumerable<CategoryModel> GetAllCategories();
        int AddCategory(CategoryInputModel taskModel);
        int DeleteCategory(int id);
        int EditCategory(int id, CategoryInputModel task);
        CategoryModel GetCategoryByID(int id);
    }
}

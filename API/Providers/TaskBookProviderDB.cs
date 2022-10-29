using API.Functions;
using API.Interfaces;
using API.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace API.Providers
{
    public class TaskBookProviderDB : ITaskBookProvider
    {
        private readonly string cs = "Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=saaanyazzz_TaskBook;User ID=saaanyazzz_TaskBook;Password=1111;TrustServerCertificate=true";

        public IEnumerable<TaskModel> GetAllTasks(string? sortParameter)
        {
            string sortByParameter = SortParameterBuilder.GetSortByCategory(sortParameter);
            string query = "SELECT TaskTable.ID, TaskDesc, Category, DeadLine, Important, Completed "+
                            "FROM TaskTable "+
                            "LEFT JOIN CategoryTable "+
                            "ON TaskTable.CategoryID = CategoryTable.ID "+
                            $"{sortByParameter} "+
                            "ORDER BY "+
                            "CASE WHEN Completed = 1 THEN 1 ELSE 0 END, "+
							"CASE WHEN DeadLine IS NULL THEN 1 ELSE 0 END, DeadLine";

            using (IDbConnection db = new SqlConnection(cs))
            {                
                var tasks = db.Query<TaskModel>(query).ToList();
                return tasks;
            }
        }

        public int AddTask(TaskInputModel taskInputModel)
        {
            string query = "INSERT INTO TaskTable (TaskDesc, CategoryID, DeadLine, Important, Completed) " +
                            "OUTPUT Inserted.ID "+
                            $"VALUES(@TaskDesc, @CategoryID, @DeadLine, @Important, @Completed)";

            using (IDbConnection db = new SqlConnection(cs))
            {
                var id = db.QuerySingle<int>(query, taskInputModel);
                return id;
            }
        }

        public int DeleteTask(int id)
        {
            string query = "DELETE FROM TaskTable WHERE ID=@id";

            using (IDbConnection db = new SqlConnection(cs))
            {
                db.Execute(query, new { id });
                return id;
            }
        }

        public int CompleteTask(int id)
        {
            string query = "UPDATE TaskTable SET Completed=1 WHERE ID=@id";

            using (IDbConnection db = new SqlConnection(cs))
            {
                db.Execute(query, new { id });
                return id;
            }
        }

        public int EditTask(int id, TaskInputModel task)
        {
            var param = new {
                    TaskDesc = task.TaskDesc,
                    CategoryID = task.CategoryID,
                    DeadLine = task.DeadLine,
                    Important = task.Important,
                    Completed = task.Completed,
                    id = id 
                };

            string query = "UPDATE TaskTable SET " +
                "TaskDesc=@TaskDesc, " +
                "CategoryID=@CategoryID, " +
                "DeadLine=@DeadLine, " +
                "Important=@Important, " +
                "Completed=@Completed " +
                "WHERE ID=@id";

            using (IDbConnection db = new SqlConnection(cs))
            {
                db.Execute(query, param);
                return id;
            }
        }

        public TaskModel GetTaskByID(int id)
        {
            string query = "SELECT TaskTable.ID, TaskDesc, Category, DeadLine, Important, Completed " +
                            "FROM TaskTable " +
                            "LEFT JOIN CategoryTable " +
                            "ON TaskTable.CategoryID = CategoryTable.ID " +
                            "WHERE TaskTable.ID = @id";

            using (IDbConnection db = new SqlConnection(cs))
            {
                var task = db.QuerySingle<TaskModel>(query, new { id });
                return task;
            }
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            string query = "SELECT ID, Category " +
                            "FROM CategoryTable";

            using (IDbConnection db = new SqlConnection(cs))
            {
                var categories = db.Query<CategoryModel>(query).ToList();
                return categories;
            }
        }

        public int AddCategory(CategoryInputModel categoryInputModel)
        {
            string query = "INSERT INTO CategoryTable (Category) " +
                            "OUTPUT Inserted.ID " +
                            $"VALUES (@Category)";

            using (IDbConnection db = new SqlConnection(cs))
            {
                var id = db.QuerySingle<int>(query, categoryInputModel);
                return id;
            }
        }

        public int DeleteCategory(int id)
        {
            string query = "" +
                "DELETE FROM CategoryTable WHERE ID=@id DELETE FROM TaskTable WHERE CategoryID=@id";

            using (IDbConnection db = new SqlConnection(cs))
            {
                db.Execute(query, new { id });
                return id;
            }
        }

        public int EditCategory(int id, CategoryInputModel category)
        {
            var param = new
            {
                Category = category.Category,
                id = id
            };

            string query = "UPDATE CategoryTable SET Category=@Category WHERE ID=@id";

            using (IDbConnection db = new SqlConnection(cs))
            {
                db.Execute(query, param);
                return id;
            }
        }

        public CategoryModel GetCategoryByID(int id)
        {
            string query = "SELECT * FROM CategoryTable WHERE ID = @id";

            using (IDbConnection db = new SqlConnection(cs))
            {
                var category = db.QuerySingle<CategoryModel>(query, new { id });
                return category;
            }
        }
    }
}

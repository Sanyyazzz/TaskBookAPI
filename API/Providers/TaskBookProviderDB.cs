using API.Interfaces;
using API.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace API.Providers
{
    public class TaskBookProviderDB : ITaskBookProviderDB
    {
        private readonly string cs = "server=HOME-PC; database=TaskBookDB; Trusted_Connection=True;";

        public List<TaskModel> GetAllTasks()
        {
            string query = "SELECT TasksTable.ID, TaskDesc, Category, DeadLine, Important, Completed " +
                            "FROM TasksTable " +
                            "LEFT JOIN CategoriesTable " +
                            "ON TasksTable.CategoryID = CategoriesTable.ID";

            using (IDbConnection db = new SqlConnection(cs))
            {
                var tasks = db.Query<TaskModel>(query).ToList();
                return tasks;
            }
        }

        public List<CategoryModel> GetAllCategories()
        {
            string query = "SELECT ID, Category " +
                            "FROM CategoriesTable";

            using (IDbConnection db = new SqlConnection(cs))
            {
                var categories = db.Query<CategoryModel>(query).ToList();
                return categories;
            }
        }
    }
}

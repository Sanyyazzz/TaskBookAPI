using API.Interfaces;
using API.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace API.Providers
{
    public class TaskBookProviderDB : ITaskBookProviderDB
    {
        private readonly string cs = "Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=saaanyazzz_TaskBook;User ID=saaanyazzz_TaskBook;Password=1234;TrustServerCertificate=true";

        public List<TaskModel> GetAllTasks()
        {
            string query = "SELECT TasksTable.ID, TaskDesc, Category, DeadLine, Important, Completed " +
                            "FROM TasksTable " +
                            "LEFT JOIN CategoryTable " +
                            "ON TasksTable.CategoryID = CategoryTable.ID";

            using (IDbConnection db = new SqlConnection(cs))
            {
                var tasks = db.Query<TaskModel>(query).ToList();
                return tasks;
            }
        }

        public List<CategoryModel> GetAllCategories()
        {
            string query = "SELECT ID, Category " +
                            "FROM CategoryTable";

            using (IDbConnection db = new SqlConnection(cs))
            {
                var categories = db.Query<CategoryModel>(query).ToList();
                return categories;
            }
        }
    }
}

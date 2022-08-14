namespace API.Models
{
    public class TaskInputModel
    {
        public TaskInputModel() { }

        public TaskInputModel(string taskDesc, int categoryID, DateTime deadLine, bool important, bool completed)
        {
            TaskDesc = taskDesc;
            CategoryID = categoryID;
            DeadLine = deadLine;
            Important = important;
            Completed = completed;
        }

        public string TaskDesc { get; set; }
        public int? CategoryID { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool? Important { get; set; } = false;
        public bool? Completed { get; set; } = false;
    }
}

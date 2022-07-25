namespace API.Models
{
    public class TaskModel
    {
        public TaskModel() { }

        public TaskModel(int Id, string taskDesc, string category, DateTime deadLine, bool important, bool completed)
        {
            ID = Id;
            TaskDesc = taskDesc;
            Category = category;
            DeadLine = deadLine == DateTime.MinValue ? null : deadLine;
            Important = important;
            Completed = completed;
        }

        public int ID { get; set; }
        public string TaskDesc { get; set; }
        public string? Category { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool? Important { get; set; }
        public bool? Completed { get; set; }
    }
}

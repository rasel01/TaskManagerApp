using System.Data.Entity;

namespace TaskManager.Models
{
    public class TaskManagerContext:DbContext 
    {
        public TaskManagerContext(): base("TaskManagerApp")
        {

        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<SubTask> SubTasks { get; set; }
    }
}

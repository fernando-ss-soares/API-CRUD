using Microsoft.EntityFrameworkCore;
using Task = Taskify.Models.Task;

namespace Taskify.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            
        }

        public DbSet<Task> Tasks { get; set; }

    }
}

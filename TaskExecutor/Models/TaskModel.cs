using Microsoft.OpenApi.Extensions;

namespace TaskExecutor.Models
{
    public class TaskModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public string StatusName => Status.GetDisplayName();
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ScheduledOn { get; set; }
        public DateTime? CompletedOn { get; set; }
    }

    public enum TaskStatus
    {
        Pending,
        Running,
        Completed,
        Failed
    }
}

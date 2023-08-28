using TaskExecutor.Models;
using TaskStatus = TaskExecutor.Models.TaskStatus;

namespace TaskExecutor.Services
{
    public class TaskService : ITaskService
    {
        public List<TaskModel> Tasks { get; private set; } = new();

        public IEnumerable<TaskModel> Get(Func<TaskModel, bool> predicate)
        {
            return Tasks.Where(predicate);
        }
        public string Add()
        {
            var task = new TaskModel();
            Tasks.Add(task);
            return task.Id;
        }

        public void Remove(string id)
        {
            var task = Tasks.Find(x => x.Id == id);
            if (task != null)
            {
                Tasks.Remove(task);
            }
        }

        public TaskModel Update(TaskModel task)
        {
            var existingTask = Tasks.Find(x => x.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.ScheduledOn = task.ScheduledOn;
                existingTask.CompletedOn = task.CompletedOn;
                existingTask.Status =task.Status;
            }

            return existingTask;
        }

        public TaskModel UpdateStatus(TaskModel task, TaskStatus status)
        {
            var existingTask = Tasks.Find(x => x.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Status = status;
            }

            return existingTask;
        }
    }
}

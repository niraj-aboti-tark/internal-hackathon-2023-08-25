using TaskExecutor.Models;
using TaskStatus = TaskExecutor.Models.TaskStatus;

namespace TaskExecutor.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> Get(Func<TaskModel, bool> predicate);
        string Add();
        void Remove(string id);
        TaskModel Update(TaskModel task);
        TaskModel UpdateStatus(TaskModel task, TaskStatus status);

    }
}

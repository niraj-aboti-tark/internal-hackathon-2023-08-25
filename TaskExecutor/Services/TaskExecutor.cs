using TaskExecutor.Models;

namespace TaskExecutor.Services
{
    public class TaskExecutor : ITaskExecutor
    {
        private readonly ITaskService _taskService;
        private readonly INodeService _nodeService;

        public TaskExecutor(ITaskService taskService, INodeService nodeService)
        {
            _taskService = taskService;
            _nodeService = nodeService;
        }

        public void Execute()
        {
            while (true)
            {
                var pendingTask = _taskService.Get(x => x.Status == Models.TaskStatus.Pending).FirstOrDefault();
                if (pendingTask == null)
                {
                    continue;
                }
                var node = _nodeService.Get(x => x.Status == NodeStatus.Available).FirstOrDefault();
                if (node != null)
                {
                    pendingTask.Status = Models.TaskStatus.Running;
                    _taskService.Update(pendingTask);
                    //Call api to process task
                    var response = ""; //api response
                    if (response is "failed")
                    {
                        pendingTask.Status = Models.TaskStatus.Failed;
                    }
                    else
                    {
                        pendingTask.Status = Models.TaskStatus.Completed;
                    }
                    _taskService.Update(pendingTask);
                }
            }
        }
    }
}

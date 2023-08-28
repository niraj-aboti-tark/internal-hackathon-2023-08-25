using Microsoft.AspNetCore.Mvc;
using TaskExecutor.Services;

namespace TaskExecutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ITaskExecutor _taskExecutor;

        public TaskController(ITaskService taskService, ITaskExecutor taskExecutor)
        {
            _taskService = taskService;
            _taskExecutor = taskExecutor;
        }
        [HttpPost]
        [Route("schedule")]
        public IActionResult ScheduleTask()
        {
            var taskId = _taskService.Add();
            return Ok($"Your task scheduled with id '{taskId}'");
        }

        [HttpGet]
        [Route("{taskId}")]
        public IActionResult GetScheduleTask([FromRoute] string taskId)
        {
            var task = _taskService.Get(x => x.Id == taskId).FirstOrDefault();
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPIProject.Services.Tasks;

namespace TaskAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskRepository _taskService;

        public TasksController(ITaskRepository repository)
        {
            _taskService = repository;
        }

        //get all tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.AllTasks();
            return Ok(tasks);
        }

        //Get single Task
        [HttpGet("{id}")]
        public IActionResult GetSingleTask(int id)
        {
            var task = _taskService.GetTask(id);
            if (task is null) return NotFound();

            return Ok(task);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPIProject.Services;

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
        [HttpGet("{id?}")]
        public IActionResult GetAllTasks(int? id)
        {
            //Get data
            var tasks = _taskService.AllTasks();

            //check whether request has a parameter (if No paramter)
            if (id is null) return Ok(tasks);

            //if there is a parameter
            tasks = tasks.Where(todo => todo.Id == id).ToList();
            return Ok(tasks);
        }

        

    }
}

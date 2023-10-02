using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        //get all tasks
        [HttpGet]
        public IActionResult Tasks()
        {
            var tasks = new string[] { "Task1", "Task2", "Task3" }; 
            return Ok(tasks);
        }
    }
}

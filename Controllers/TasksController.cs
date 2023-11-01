using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPIProject.Models;
using TaskAPIProject.Services.Models;
using TaskAPIProject.Services.Tasks;
using Task = TaskAPIProject.Models.Task;

namespace TaskAPIProject.Controllers
{
    [Route("api/authors/{authorId}/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskService;
        private readonly IMapper _mapper;

        public TasksController(ITaskRepository repository, IMapper mapper)
        {
            _taskService = repository;
            _mapper = mapper;
        }

        //get all tasks
        [HttpGet]
        public ActionResult<ICollection<TaskDto>> GetAllTasks(int authorId)
        {
            var tasks = _taskService.AllTasks(authorId);

            var mappedTasks = _mapper.Map<ICollection<TaskDto>>(tasks);
            return Ok(mappedTasks);
        }

        //Get single Task
        [HttpGet("{id}", Name = "GetSingleTask")]
        public IActionResult GetSingleTask(int authorId, int id)
        {
            var task = _taskService.GetTask(authorId, id);
            if (task is null) return NotFound();

            var mappedTask = _mapper.Map<TaskDto>(task);

            return Ok(mappedTask);
        }

        [HttpPost]
        public ActionResult<TaskDto> CreateTask(int authorId,  CreateTaskDto task)
        {
            var taskEntity = _mapper.Map<Task>(task);
            
            var newtask = _taskService.CreateTask(authorId,taskEntity);

            var taskForReturn = _mapper.Map<TaskDto>(newtask);
            
            return CreatedAtRoute("GetSingleTask", new {authorId = authorId, id = taskForReturn.Id}, taskForReturn);
        }

        [HttpPut ("{taskId}")]
        public ActionResult UpdateTsk(int authorId, int taskId, UpdateTaskDto task)
        {
            var updatingTask = _taskService.GetTask(authorId, taskId);

            if(updatingTask is null) return NotFound();

            _mapper.Map(task, updatingTask);

            _taskService.UpdateTask(updatingTask);

            return NoContent();
        }

        [HttpDelete ("{taskId}")]
        public ActionResult DeleteTask(int authorId, int taskId)
        {
            var deletingTask = _taskService.GetTask(authorId, taskId);

            if (deletingTask is null) return NotFound();

            _taskService.DeleteTask(deletingTask);

            return NoContent();
        }

    }
}

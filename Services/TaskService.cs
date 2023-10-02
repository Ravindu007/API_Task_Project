using Task = TaskAPIProject.Models.Task;
using TaskStatus = TaskAPIProject.Models.TaskStatus;

namespace TaskAPIProject.Services
{
    public class TaskService
    {
        //Data for COntroller
        public List<Task> AllTasks()
        {
            var tasks = new List<Task>();

            var task1 = new Task
            {
                Id = 1,
                Title = "Complete ASP.Net Project before thursday",
                Description = "Follow tutorial",
                Created = DateTime.Now,
                Due = DateTime.Now.AddDays(5),
                status = TaskStatus.New
            };
            tasks.Add(task1);

            var task2 = new Task
            {
                Id = 2,
                Title = "Update LinkedIn",
                Description = "Update ASP.net Content",
                Created = DateTime.Now,
                Due = DateTime.Now.AddDays(5),
                status = TaskStatus.New
            };
            tasks.Add(task2);

            return tasks;
        }
    }
}

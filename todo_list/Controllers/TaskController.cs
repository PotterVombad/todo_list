using Microsoft.AspNetCore.Mvc;
using ToDoList.Service.Interfaces;
using ToDoListDomain_0.Filters.Task;
using ToDoListDomain_0.ViewModels.Task;

namespace todo_list.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel model)
        {
            var response = await _taskService.Create(model);
            if (response.StatusCode == ToDoListDomain_0.Enum_0.StatusCode.OK)
            {
                return Ok(new {description =  response.Description});
            }
            return BadRequest(error: new { description = response.Description });
        }
        public async Task<IActionResult> TaskHandler(TaskFilter filter)
        {
            var response = await _taskService.GetTasks(filter);

            return Json(data: new { data = response.Data });
        }

    }
}
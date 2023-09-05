using ToDoList.Service.Interfaces;
using ToDoListDomain_0.Entity_0;
using ToDoListDomain_0.Responce;
using ToDoListDomain_0.ViewModels.Task;
using ToDoListDal_0.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ToDoListDomain_0.Enum_0;
using ToDoListDomain_0.Extencions;
using ToDoListDomain_0.Filters.Task;

namespace ToDoList.Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IBaseRepository<TaskEntity> _taskRepository;
        private ILogger<TaskService> _logger;

        public TaskService(IBaseRepository<TaskEntity> taskRepository, ILogger<TaskService> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<IBaseResponce<TaskEntity>> Create(CreateTaskViewModel model)
        {
            try
            {
                model.Validate();
                _logger.LogInformation(message: $"Запрос на создание задачи - {model.Name}");
                var task = await _taskRepository.GetAll()
                    .Where(x => x.Created.Date == DateTime.Today)
                    .FirstOrDefaultAsync(x => x.Name == model.Name);
                if (task != null)
                {
                    return new BaseResponce<TaskEntity>()
                    {
                        Description = "Задача с таким названием уже есть",
                        StatusCode = StatusCode.TaskIsHasAlready
                    };
                }
                task = new TaskEntity()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Priority = model.Priority,
                    Created = DateTime.Now,
                    IsDone = false
                };
                await _taskRepository.Create(task);

                _logger.LogInformation($"Задача создалась: {task.Name} {task.Created}");
                return new BaseResponce<TaskEntity>()
                {
                    Description = "Задача создалась",
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, message: $"[TaskServise.Create]: {ex.Message}");
                return new BaseResponce<TaskEntity>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<IEnumerable<TaskViewModel>>> GetTasks(TaskFilter filter)
        {
            try
            {
                var tasks = await _taskRepository.GetAll()
                    .WhereIf(condition: !string.IsNullOrWhiteSpace(filter.Name), predicate: x  => x.Name == filter.Name)
                    .WhereIf(condition: filter.Priority.HasValue, predicate: x => x.Priority == filter.Priority)
                    .Select(x => new TaskViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        IsDone = x.IsDone == true? "Готово": "В процессе",
                        Priority = x.Priority.GetDisplayName(),
                        Created = x.Created.ToLongDateString()

                    })
                    .ToListAsync();
                return new BaseResponce<IEnumerable<TaskViewModel>>()
                {
                    Data = tasks,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, message: $"[TaskServise.Create]: {ex.Message}");
                return new BaseResponce<IEnumerable<TaskViewModel>> ()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}

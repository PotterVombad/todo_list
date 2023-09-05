using ToDoListDomain_0.Entity_0;
using ToDoListDomain_0.Filters.Task;
using ToDoListDomain_0.Responce;
using ToDoListDomain_0.ViewModels.Task;

namespace ToDoList.Service.Interfaces
{
    public interface ITaskService
    {
        Task<IBaseResponce<TaskEntity>> Create(CreateTaskViewModel model);

        Task<IBaseResponce<IEnumerable<TaskViewModel>>> GetTasks(TaskFilter filter);
    }
}

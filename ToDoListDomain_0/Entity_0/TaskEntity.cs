using ToDoListDomain_0.Enum_0;

namespace ToDoListDomain_0.Entity_0
{
    public class TaskEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }  
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public Priority Priority { get; set; }
    }
}

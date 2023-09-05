using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDomain_0.Enum_0;

namespace ToDoListDomain_0.Filters.Task
{
    public class TaskFilter
    {
        public string Name { get; set; }
        public Priority? Priority { get; set; }
    }
}

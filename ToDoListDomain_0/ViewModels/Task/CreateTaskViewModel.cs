﻿using ToDoListDomain_0.Enum_0;

namespace ToDoListDomain_0.ViewModels.Task
{
    public class CreateTaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException(Name, message: "Укажите название задачи");
            }
            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new ArgumentNullException(Name, message: "Укажите описание задачи");
            }
        }
    }
}



using System.ComponentModel.DataAnnotations;

namespace ToDoListDomain_0.Enum_0
{
    public enum Priority
    {
        [Display(Name = "Простая")]
        Easy = 1,
        [Display(Name = "Средняя")]
        Medium = 2,
        [Display(Name = "Сложная")]
        Hard = 3    
    }
}

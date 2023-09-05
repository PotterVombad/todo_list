using ToDoListDomain_0.Enum_0;

namespace ToDoListDomain_0.Responce
{
    public class BaseResponce<T> : IBaseResponce<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
    public interface IBaseResponce<T>
    {
        string Description { get; set; }
        StatusCode StatusCode { get; set; }
        T Data { get; }
    }

}

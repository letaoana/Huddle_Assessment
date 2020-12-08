using RestSharp;

namespace Huddle.Todo.API
{
    public interface IApi
    {
        IRestResponse GetAllTodos();
    }
}

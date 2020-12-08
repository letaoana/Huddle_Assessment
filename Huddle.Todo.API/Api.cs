using RestSharp;

namespace Huddle.Todo.API
{
    public class Api : IApi
    {
        private readonly IRestClient client;
        private IRestRequest request;

        public Api()
        {
            client = new RestClient("https://jsonplaceholder.typicode.com");
            client.ClearHandlers();
        }

        public IRestResponse GetAllTodos()
        {
            request = new RestRequest
            {
                Resource = "/todos"
            };
            return client.Execute(request, Method.GET);
        }
    }
}

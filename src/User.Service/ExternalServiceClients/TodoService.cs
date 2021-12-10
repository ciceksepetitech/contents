using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using User.Core.Settings;
using User.Service.ExternalServiceClients.Response;

namespace User.Service.ExternalServiceClients
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;
        private readonly ToDoServiceSettings _toDoServiceSettings;
        
        public TodoService(IHttpClientFactory httpClientFactory,
            IOptions<ToDoServiceSettings> toDoServiceSettings)
        {
            _toDoServiceSettings = toDoServiceSettings.Value;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<GetToDoResponse> GetUserTodo(int id)
        {
            var todoResponse = new GetToDoResponse();

            var response = await _httpClient.GetStringAsync($"{_toDoServiceSettings.Url}todos/user/{id}");

            if (string.IsNullOrEmpty(response))
                return todoResponse;

            todoResponse = JsonConvert.DeserializeObject<GetToDoResponse>(response);

            return todoResponse;
        }
    }
}

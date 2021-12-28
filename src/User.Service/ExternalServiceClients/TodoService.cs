using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using User.Core.Settings;
using User.Service.Dto;
using User.Service.ExternalServiceClients.Response;

namespace User.Service.ExternalServiceClients
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;
        private readonly ToDoServiceSettings _toDoServiceSettings;
        private readonly ILogger<TodoService> _logger;

        public TodoService(IHttpClientFactory httpClientFactory,
            IOptions<ToDoServiceSettings> toDoServiceSettings,
            ILogger<TodoService> logger)
        {
            _logger = logger;
            _toDoServiceSettings = toDoServiceSettings.Value;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<GetToDoResponse> GetUserTodo(int id)
        {
            var todoResponse = new GetToDoResponse();

            var url = $"{_toDoServiceSettings.Url}todos/user/{id}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("get todo service error", url);
                return new GetToDoResponse() { ToDos = new List<ToDoItemDto>() };
            }

            var content = await response.Content.ReadAsStringAsync();

            todoResponse = JsonConvert.DeserializeObject<GetToDoResponse>(content);

            return todoResponse;
        }
    }
}

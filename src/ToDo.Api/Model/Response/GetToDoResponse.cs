using System.Collections.Generic;

namespace ToDo.Api.Model.Response
{
    public class GetToDoResponse
    {
        public List<ToDoItem> ToDos { get; set;}
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Model;
using ToDo.Api.Model.Response;

namespace ToDo.Api.Controllers
{
    [Route("api/v1/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // GET: api/v1/todos/user/1
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetToDo(int id)
        {
            return Ok(new GetToDoResponse()
            {
                ToDos = new List<ToDoItem>()
                {
                    new()
                    {
                        Id = 1,
                        Name = "Lorem Ipsum",
                        IsCompleted = true,
                        ExpireDate = DateTime.Now.AddHours(5)
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Lorem Ipsum 2",
                        IsCompleted = false,
                        ExpireDate = DateTime.Now.AddHours(10)
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Lorem Ipsum 3",
                        IsCompleted = false,
                        ExpireDate = DateTime.Now.AddHours(20)
                    }
                }
            });
        }
}
}

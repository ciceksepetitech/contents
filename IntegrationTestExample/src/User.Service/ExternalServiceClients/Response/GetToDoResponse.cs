using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Service.Dto;

namespace User.Service.ExternalServiceClients.Response
{
    public class GetToDoResponse
    {
        public List<ToDoItemDto> ToDos { get; set; }
    }
}

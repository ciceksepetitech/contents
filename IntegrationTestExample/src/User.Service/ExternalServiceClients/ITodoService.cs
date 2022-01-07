using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Service.ExternalServiceClients.Response;

namespace User.Service.ExternalServiceClients
{
    public interface ITodoService
    {
        Task<GetToDoResponse> GetUserTodo(int id);

    }
}

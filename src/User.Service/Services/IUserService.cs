using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Core.Domain;
using User.Service.Dto;

namespace User.Service.Services
{
    public interface IUserService
    {
        Task<UserDomain> AddUser(UserDto userDto);
        Task<List<UserDomain>> GetUsers(int id, string name, byte age);
        Task<GetUserResponseDto> GetUser(int id, bool includeUserTodoList);
        Task<bool> UpdateUser(int id, string name, byte age);
        Task<bool> DeleteUser(int id);
    }
}

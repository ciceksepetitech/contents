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
    }
}

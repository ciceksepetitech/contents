using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using User.Core.Domain;
using User.Data.Context;
using User.Service.Dto;
using User.Service.ExternalServiceClients;

namespace User.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;
        private readonly ITodoService _todoService;

        public UserService(UserContext userContext,
            IMapper mapper, 
            ITodoService todoService)
        {
            _userContext = userContext;
            _mapper = mapper;
            _todoService = todoService;
        }

        public async Task<UserDomain> AddUser(UserDto userDto)
        {
            var userDomain = _mapper.Map<UserDto, UserDomain>(userDto);

            var userEntity = await _userContext.Users.AddAsync(userDomain);

            await _userContext.SaveChangesAsync();

            return userEntity.Entity;
        }

        public async Task<List<UserDomain>> GetUsers(int id, string name, byte age)
        {
            return await GetUsersList(id,name,age);
        }

        public async Task<GetUserResponseDto> GetUser(int id, bool includeUserTodoList)
        {
            var user = (await GetUsersList(id, null, 0)).FirstOrDefault();

            var userDto = _mapper.Map<UserDomain, GetUserResponseDto>(user);

            if (includeUserTodoList)
                userDto.ToDos = (await _todoService.GetUserTodo(id))?.ToDos;

            return userDto;
        }

        public async Task<bool?> UpdateUser(int id, string name, byte age)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (user == null)
                return null;

            user.Age=age;
            user.Name = name;

            var affectedRowCount = await _userContext.SaveChangesAsync();

            return affectedRowCount > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (user == null)
                return false;

            _userContext.Remove(user);

            var affectedRowCount = await _userContext.SaveChangesAsync();

            return affectedRowCount > 0;
        }

        private async Task<List<UserDomain>> GetUsersList(int id, string name, byte age)
        {
            var userListAsQueryable = _userContext.Users.AsQueryable();

            if (id != default)
                userListAsQueryable = userListAsQueryable.Where(x => x.UserId == id);

            if (age != default)
                userListAsQueryable = userListAsQueryable.Where(x => x.Age == age);

            if (!string.IsNullOrEmpty(name))
                userListAsQueryable = userListAsQueryable.Where(x => x.Name == name);

            var userList = await userListAsQueryable.ToListAsync();

            return userList;
        }



    }
}

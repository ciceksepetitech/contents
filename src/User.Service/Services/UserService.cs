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

namespace User.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;
        public UserService(UserContext userContext,
            IMapper mapper)
        {
            _userContext = userContext;
            _mapper = mapper;
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

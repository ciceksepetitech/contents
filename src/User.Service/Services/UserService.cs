using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using User.Core.Domain;
using User.Data.Context;
using User.Service.Dto;

namespace User.Service.Services
{
    public class UserService:IUserService
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
    }
}

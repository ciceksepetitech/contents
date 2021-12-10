using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Api.Models.Request;
using User.Api.Models.Response;
using User.Core.Domain;
using User.Service.Dto;
using User.Service.Services;

namespace User.Api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // POST: api/v1/users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] PostUserRequest request)
        {
            var response = new PostUserResponse();

            var dto = _mapper.Map<PostUserRequest, UserDto>(request);

            var result = await _userService.AddUser(dto);

            response = _mapper.Map<UserDomain, PostUserResponse>(result);

            return Created($"{Request.Host.Value}{Request.Path}/{response.UserId}", response);
        }


        // GET: api/v1/users
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            var response = new GetUsersResponse();

            var result = await _userService.GetUsers(request.Id, request.Name, request.Age);

            var userList = _mapper.Map<List<UserDomain>, List<UserDto>>(result);

            response.UserList = userList;
            response.Count = userList.Count;

            return Ok(response);
        }


        // GET: api/v1/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id, [FromQuery] bool includeUserTodoList)
        {
            var response = new GetUserResponse();

            var result = await _userService.GetUser(id,includeUserTodoList);

            if (result == null)
                return NotFound();

            response = _mapper.Map<GetUserResponseDto, GetUserResponse>(result);

            return Ok(response);
        }


        // PUT: api/v1/users/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] PutUserRequest request)
        {
            
            var result = await _userService.UpdateUser(id,request.Name, (byte)request.Age);

            if (!result)
                return NotFound();

            return NoContent();
        }


        // DELETE: api/v1/users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);

            if (!result)
                return NotFound();

            return NoContent();
        }


    }
}

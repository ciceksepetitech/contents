using System.Collections.Generic;
using User.Service.Dto;

namespace User.Api.Models.Response
{
    public class GetUsersResponse
    {
        public int Count { get; set; }

        public List<UserDto> UserList { get; set; }
    }
}

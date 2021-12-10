using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Service.Dto
{
    public class GetUserResponseDto:UserDto
    {
        public List<ToDoItemDto> ToDos { get; set; }

    }
}

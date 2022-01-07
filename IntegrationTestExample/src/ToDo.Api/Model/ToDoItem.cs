using System;
using System.Security.AccessControl;

namespace ToDo.Api.Model
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}

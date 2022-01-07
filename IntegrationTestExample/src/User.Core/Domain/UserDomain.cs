using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Core.Domain
{
    public class UserDomain
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class SpecialRoleDto
    {
        public int UserId { get; set; }
        public string RoleType { get; set; }

        public UserDto User { get; set; }
    }
}

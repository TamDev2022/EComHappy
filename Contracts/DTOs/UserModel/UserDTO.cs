using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs.UserModel
{
    public class UserDTO
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }
    }
}

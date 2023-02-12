using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTOs
{
    public class UserTokenModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

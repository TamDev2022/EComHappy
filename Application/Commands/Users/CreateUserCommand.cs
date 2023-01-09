using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Avatar { get; set; }

        public Guid RoleId { get; set; }

        public CreateUserCommand(string userName, string email, string password, string phoneNumber, string avatar, Guid roleId)
        {
            UserName = userName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
            RoleId = roleId;

        }
    }
}

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
        [DataMember]
        public string UserId { get; private set; }

        public CreateUserCommand(string userId)
        {
            UserId = userId;
        }
    }
}

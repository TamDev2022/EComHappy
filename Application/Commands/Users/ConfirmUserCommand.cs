using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public class ConfirmUserCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public string VerifyCode { get; set; }
    }
}

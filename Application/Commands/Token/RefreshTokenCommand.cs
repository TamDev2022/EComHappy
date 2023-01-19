using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Token
{
    public class RefreshTokenCommand : IRequest<bool>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

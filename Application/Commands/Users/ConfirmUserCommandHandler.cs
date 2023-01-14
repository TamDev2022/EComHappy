using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public class ConfirmUserCommandHandler : IRequestHandler<ConfirmUserCommand, bool>
    {
        public Task<bool> Handle(ConfirmUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}

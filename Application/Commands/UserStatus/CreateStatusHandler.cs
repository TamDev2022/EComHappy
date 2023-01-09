using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserStatus
{
    public class CreateStatusHandler : IRequestHandler<CreateStatus, bool>
    {
        public CreateStatusHandler()
        {

        }
        public Task<bool> Handle(CreateStatus request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

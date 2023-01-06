using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.DomainEventHandlers.Users
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public User User { get; set; }
    }
}

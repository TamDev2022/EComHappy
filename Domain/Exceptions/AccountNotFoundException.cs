using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class AccountNotFoundException : NotFoundException
    {
        public AccountNotFoundException(Guid accountId)
            : base($"The account with the identifier {accountId} was not found.")
        {
        }
    }
}

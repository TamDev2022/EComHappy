using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserStatusTrans : IAggregateRoot
    {
        public Guid StatusId { get; set; }
        public UserStatus UserStatus { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}

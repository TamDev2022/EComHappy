using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserStatus : BaseEntity<int>, IAggregateRoot
    {
        public string StatusName { get; set; }

        public virtual User User { get; set; }

    }
}

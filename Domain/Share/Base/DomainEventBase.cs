using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Share.Base
{
    public class DomainEventBase : IDomainEvent
    {
        public DomainEventBase()
        {
            OccurredOn = DateTime.Now;
        }

        public DateTime OccurredOn { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        Task HandleAsync(T domainEvent, CancellationToken cancellationToken = default);
    }
}

using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class EntityUpdatedEvent<T> : IDomainEvent where T : BaseEntity<Guid>
    {
        public EntityUpdatedEvent(T entity, DateTime eventDateTime)
        {
            Entity = entity;
            EventDateTime = eventDateTime;
        }

        public T Entity { get; }

        public DateTime EventDateTime { get; }

        public DateTime OccurredOn => throw new NotImplementedException();
    }
}

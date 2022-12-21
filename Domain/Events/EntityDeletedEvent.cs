using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class EntityDeletedEvent<T> : IDomainEvent where T : BaseEntity<Guid>
    {
        public EntityDeletedEvent(T entity, DateTime eventDateTime)
        {
            Entity = entity;
            EventDateTime = eventDateTime;
        }

        public T Entity { get; }

        public DateTime EventDateTime { get; }
    }
}

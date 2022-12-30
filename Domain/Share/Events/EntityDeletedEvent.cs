using Domain.Share.Base;

namespace Domain.Share.Events
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
        public DateTime OccurredOn => throw new NotImplementedException();
    }
}

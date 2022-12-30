using Domain.Share.Base;

namespace Domain.Share.Events
{
    public class EntityCreatedEvent<T> : IDomainEvent where T : BaseEntity<Guid>
    {
        public EntityCreatedEvent(T entity, DateTime eventDateTime)
        {
            Entity = entity;
            EventDateTime = eventDateTime;
        }

        public T Entity { get; }

        public DateTime EventDateTime { get; }

        public DateTime OccurredOn => throw new NotImplementedException();
    }

}



namespace Domain.Share.Base
{
    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        public void AddDomainEvent(IDomainEvent domainEvent);
        public void ClearDomainEvents();
    }

    public abstract class BaseEntity<TKey> : IHasKey<TKey>, ITrackable, IEntity
    {
        public TKey Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; }

        public DateTimeOffset? UpdatedDateTime { get; set; }

        private List<IDomainEvent> _domainEvents;

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

    }
}

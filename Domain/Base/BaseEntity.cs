using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
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

        public string? CreatedDateTime { get; set; }

        public string? UpdatedDateTime { get; set; }

        private List<IDomainEvent> _domainEvents;

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            this._domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

    }
}

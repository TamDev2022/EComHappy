using Domain.Share.Base;

namespace Domain.AggregatesModel.AudiLogEntryAggregate
{
    public class AuditLogEntry : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid UserId { get; set; }

        public string Action { get; set; }

        public string ObjectId { get; set; }

        public string Log { get; set; }
    }
}

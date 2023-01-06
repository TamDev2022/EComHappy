using Domain.Base;


namespace Domain.Entities
{
    public class AuditLogEntry : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid UserId { get; set; }

        public string Action { get; set; }

        public string ObjectId { get; set; }

        public string Log { get; set; }

        public Product Product
        {
            get => default;
            set
            {
            }
        }
    }
}

using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AuditLogEntry : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid UserId { get; set; }

        public string Action { get; set; }

        public string ObjectId { get; set; }

        public string Log { get; set; }
    }
}

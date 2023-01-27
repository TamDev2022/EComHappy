using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetail : BaseEntity<Guid>, IAggregateRoot
    {
        public string Note { get; set; }

        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}

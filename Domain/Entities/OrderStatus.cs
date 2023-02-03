using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderStatus : BaseEntity<int>, IAggregateRoot
    {
        public string StatusName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

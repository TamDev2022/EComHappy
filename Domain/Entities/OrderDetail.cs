using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetail : BaseEntity<int>, IAggregateRoot
    {
        public string Note { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}

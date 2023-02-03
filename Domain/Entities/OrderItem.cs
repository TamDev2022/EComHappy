using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem : IAggregateRoot
    {

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public int ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }

        public int Quantity { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem : IAggregateRoot
    {

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Guid ProductItemId { get; set; }
        public ProductItem ProductItem { get; set; }

        public int Quantity { get; set; }

    }
}

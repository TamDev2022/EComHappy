using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem : IAggregateRoot
    {
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public Guid ProductId { get; set; }
        public Guid ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
    }
}

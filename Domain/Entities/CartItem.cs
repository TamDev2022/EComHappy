using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem : IAggregateRoot
    {
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public int ProductId { get; set; }
        public int ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
    }
}

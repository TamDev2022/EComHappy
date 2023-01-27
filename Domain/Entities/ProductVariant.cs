using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductVariant : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string SKU { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public virtual IList<CartItem> CartItems { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }

        public virtual IList<ProductVariantValue> ProductVariantValues { get; set; }
        public virtual ICollection<ProductMedia> ProductMedias { get; set; }


    }
}

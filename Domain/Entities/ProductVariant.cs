using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductVariant : BaseEntity<int>, IAggregateRoot
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string SKU { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual ICollection<VariantValue> VariantValues { get; set; }
        public virtual ICollection<ProductMedia> ProductMedias { get; set; }


    }
}

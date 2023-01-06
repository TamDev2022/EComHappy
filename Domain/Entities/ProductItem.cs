using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductItem : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public string SKU { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public IList<CartItem> CartItems { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        //public IList<ProductValueTrans> ProductValueTrans { get; set; }
        public ICollection<ProductMedia> ProductMedias { get; set; }


    }
}

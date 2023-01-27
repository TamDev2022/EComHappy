using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductOptionTrans : IAggregateRoot
    {
        public Guid ProductId { get; set; }
        public Guid ProductOptionId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductOption ProductOption { get; set; }
        public virtual IList<ProductVariantValue> ProductVariantValues { get; set; }
    }
}

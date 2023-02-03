using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductOptionValue : BaseEntity<int>, IAggregateRoot
    {
        public int ProductOptionId { get; set; }

        public string ValueName { get; set; }

        public virtual ProductOption ProductOption { get; set; }
        public virtual IList<ProductVariantValue> ProductVariantValues { get; set; }


    }
}

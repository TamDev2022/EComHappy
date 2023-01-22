using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductOptionValue : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid ProductOptionId { get; set; }

        public string ValueName { get; set; }

        public ProductOption ProductOption { get; set; }
        public IList<ProductVariantValue> ProductVariantValues { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductVariantValue : IAggregateRoot
    {
        public Guid ProductId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Guid ProductOptionId { get; set; }
        public Guid OptionValueId { get; set; }

        public ProductVariant ProductVariant { get; set; }
        public ProductOptionTrans ProductOptionTrans { get; set; }
        public ProductOptionValue ProductOptionValue { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductVariantValue : IAggregateRoot
    {
        public int ProductId { get; set; }
        public int ProductVariantId { get; set; }
        public int ProductOptionId { get; set; }
        public int OptionValueId { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }
        public virtual ProductOptionTrans ProductOptionTrans { get; set; }
        public virtual ProductOptionValue ProductOptionValue { get; set; }


    }
}

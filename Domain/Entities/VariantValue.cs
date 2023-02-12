using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VariantValue : IAggregateRoot
    {
        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public int OptionId { get; set; }
        public int OptionValueId { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }
        //public virtual ProductOption ProductOption { get; set; }
        public virtual OptionValue OptionValue { get; set; }


    }
}

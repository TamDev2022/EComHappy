using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductValueTrans : IAggregateRoot
    {
        public Guid ProductId { get; set; }
        public Guid ProductItemId { get; set; }
        public ProductItem ProductItem { get; set; }

        public Guid OptionId { get; set; }
        public Guid OptionValueId { get; set; }
        public ProductOptionValue ProductOptionValue { get; set; }


    }
}

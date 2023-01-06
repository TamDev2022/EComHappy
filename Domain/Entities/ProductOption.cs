using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductOption : BaseEntity<Guid>, IAggregateRoot
    {
        public string OptionName { get; set; }

        public IList<ProductOptionTrans> ProductOptionTrans { get; set; }

        public ICollection<ProductOptionValue> ProductOptionValues { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductOption : IAggregateRoot
    {
        public int ProductId { get; set; }
        public int OptionId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Option Option { get; set; }
        //public virtual ICollection<VariantValue> VariantValues { get; set; }
    }
}

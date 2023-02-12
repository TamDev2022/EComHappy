using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Option : BaseEntity<int>, IAggregateRoot
    {
        public string OptionName { get; set; }

        public virtual ICollection<OptionValue> OptionValues { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OptionValue : BaseEntity<int>, IAggregateRoot
    {
        public int OptionId { get; set; }

        public string ValueName { get; set; }

        public virtual Option Option { get; set; }
        public virtual ICollection<VariantValue> VariantValues { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity<Guid>, IAggregateRoot
    {

        public string ProductName { get; set; }

        public Guid BranId { get; set; }
        public virtual Brand Brand { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
        public virtual IList<ProductOptionTrans> ProductOptionTrans { get; set; }
    }
}

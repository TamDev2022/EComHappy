using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity<int>, IAggregateRoot
    {

        public string ProductName { get; set; }
        public string Description { get; set; }


        public int BranId { get; set; }
        public virtual Brand Brand { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductOption> ProductOptions { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}

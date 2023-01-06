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
        public Brand Brand { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductItem> ProductItems { get; set; }
        //public IList<ProductOptionTrans> ProductOptionTrans { get; set; }
    }
}

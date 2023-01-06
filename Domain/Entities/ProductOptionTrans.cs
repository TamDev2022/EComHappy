using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductOptionTrans : IAggregateRoot
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid ProductOptionId { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}

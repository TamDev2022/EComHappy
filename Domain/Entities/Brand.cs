using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand : BaseEntity<Guid>, IAggregateRoot
    {
        public string BrandName { get; set; }

        public ICollection<Product> Products { get;set; }
    }
}

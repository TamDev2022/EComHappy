using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseEntity<Guid>, IAggregateRoot
    {
        public string Value { get; set; }
        public Guid ParentCategoryId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

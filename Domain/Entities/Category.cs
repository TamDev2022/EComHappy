using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseEntity<Guid>, IAggregateRoot
    {
        public string CategoryName { get; set; }
        public Guid ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

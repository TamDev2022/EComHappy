using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductMedia : BaseEntity<int>, IAggregateRoot
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }

        public int ProductVariantId { get; set; }
        public int ProductId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
    }
}

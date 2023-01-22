using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class ProductVariantValueConfiguration : IEntityTypeConfiguration<ProductVariantValue>
    {
        public void Configure(EntityTypeBuilder<ProductVariantValue> builder)
        {
            builder.HasKey(pvv => new { pvv.ProductId, pvv.ProductVariantId, pvv.ProductOptionId });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class ProductOptionValueConfiguration : IEntityTypeConfiguration<ProductOptionValue>
    {
        public void Configure(EntityTypeBuilder<ProductOptionValue> builder)
        {
            builder.HasKey(pov => new { pov.Id, pov.ProductOptionId });
            builder.Property(pov => pov.Id).HasDefaultValueSql("newsequentialid()");

            builder.HasMany<ProductVariantValue>(pov => pov.ProductVariantValues)
                   .WithOne(pvv => pvv.ProductOptionValue)
                   .HasForeignKey(pvv => new { pvv.ProductOptionId, pvv.OptionValueId })
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

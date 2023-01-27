using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class ProductOptionTransConfiguration : IEntityTypeConfiguration<ProductOptionTrans>
    {
        public void Configure(EntityTypeBuilder<ProductOptionTrans> builder)
        {
            builder.HasKey(pot => new { pot.ProductId, pot.ProductOptionId });
            //builder.Property(pot => pot.Id)

            builder.HasMany<ProductVariantValue>(pot => pot.ProductVariantValues)
                .WithOne(pvv => pvv.ProductOptionTrans)
                .HasForeignKey(pvv => new { pvv.ProductId, pvv.ProductOptionId })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

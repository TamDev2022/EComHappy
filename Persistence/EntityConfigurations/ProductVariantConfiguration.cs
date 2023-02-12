using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasKey(pv => new { pv.Id, pv.ProductId });
            builder.Property(pv => pv.Id).ValueGeneratedOnAdd();

            builder.HasMany<CartItem>(pv => pv.CartItems)
                   .WithOne(ci => ci.ProductVariant)
                   .HasForeignKey(ci => new { ci.ProductId, ci.VariantId });

            builder.HasMany<OrderItem>(pv => pv.OrderItems)
                   .WithOne(oi => oi.ProductVariant)
                   .HasForeignKey(oi => new { oi.ProductId, oi.VariantId });

            builder.HasMany<ProductMedia>(pv => pv.ProductMedias)
                .WithOne(pm => pm.ProductVariant)
                .HasForeignKey(pm => new { pm.ProductId, pm.VariantId });

            builder.HasMany<VariantValue>(pv => pv.VariantValues)
                .WithOne(vv => vv.ProductVariant)
                .HasForeignKey(vv => new { vv.ProductId, vv.VariantId })
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

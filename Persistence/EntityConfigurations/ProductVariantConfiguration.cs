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
            builder.HasKey(pi => new { pi.Id, pi.ProductId });
            builder.Property(pi => pi.Id).ValueGeneratedOnAdd();

            builder.HasMany<CartItem>(pi => pi.CartItems)
                   .WithOne(ci => ci.ProductVariant)
                   .HasForeignKey(ci => new { ci.ProductId, ci.ProductVariantId });

            builder.HasMany<OrderItem>(pi => pi.OrderItems)
                   .WithOne(oi => oi.ProductVariant)
                   .HasForeignKey(oi => new { oi.ProductId, oi.ProductVariantId });

            builder.HasMany<ProductMedia>(pi => pi.ProductMedias)
                .WithOne(pm => pm.ProductVariant)
                .HasForeignKey(pm => new { pm.ProductId, pm.ProductVariantId });

            builder.HasMany<ProductVariantValue>(pi => pi.ProductVariantValues)
                .WithOne(pvv => pvv.ProductVariant)
                .HasForeignKey(pvv => new { pvv.ProductId, pvv.ProductVariantId })
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

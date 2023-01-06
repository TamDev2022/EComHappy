using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.HasKey(pi => new { pi.Id, pi.ProductId });

            builder.HasMany<CartItem>(pi => pi.CartItems)
                   .WithOne(ci => ci.ProductItem)
                   .HasForeignKey(ci => new { ci.ProductId, ci.ProductItemId });

            builder.HasMany<OrderItem>(pi => pi.OrderItems)
                   .WithOne(oi => oi.ProductItem)
                   .HasForeignKey(oi => new { oi.ProductId, oi.ProductItemId });

            builder.HasMany<ProductMedia>(pi => pi.ProductMedias)
                .WithOne(pm => pm.ProductItem)
                .HasForeignKey(pm => new { pm.ProductId, pm.ProductItemId });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();


            builder.HasMany<ProductVariant>(p => p.ProductVariants)
                   .WithOne(pi => pi.Product)
                   .HasForeignKey(pi => pi.ProductId);

            builder.HasMany<ProductOptionTrans>(p => p.ProductOptionTrans)
                   .WithOne(pot => pot.Product)
                   .HasForeignKey(pot => pot.ProductId);

        }
    }
}

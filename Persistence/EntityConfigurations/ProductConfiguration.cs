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
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");


            builder.HasMany<ProductItem>(p => p.ProductItems)
                   .WithOne(pi => pi.Product)
                   .HasForeignKey(pi => pi.ProductId);

        }
    }
}

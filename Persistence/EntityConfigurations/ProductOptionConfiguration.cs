using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class ProductOptionConfiguration : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder.HasKey(po => po.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");


            builder.HasMany<ProductOptionTrans>(po => po.ProductOptionTrans)
                   .WithOne(pot => pot.ProductOption)
                   .HasForeignKey(pot => pot.ProductOptionId);

            builder.HasMany<ProductOptionValue>(po => po.ProductOptionValues)
                  .WithOne(pov => pov.ProductOption)
                  .HasForeignKey(pov => pov.ProductOptionId);
        }
    }
}

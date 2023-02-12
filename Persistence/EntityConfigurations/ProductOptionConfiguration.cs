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
            builder.HasKey(pot => new { pot.ProductId, pot.OptionId });


            //builder.HasMany<VariantValue>(po => po.VariantValues)
            //    .WithOne(vv => vv.ProductOption)
            //    .HasForeignKey(vv => new { vv.ProductId, vv.OptionId })
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

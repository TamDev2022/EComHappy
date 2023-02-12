using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();


            builder.HasMany<ProductOption>(o => o.ProductOptions)
                   .WithOne(po => po.Option)
                   .HasForeignKey(po => po.OptionId);

            builder.HasMany<OptionValue>(o => o.OptionValues)
                  .WithOne(ov => ov.Option)
                  .HasForeignKey(ov => ov.OptionId);
        }
    }
}

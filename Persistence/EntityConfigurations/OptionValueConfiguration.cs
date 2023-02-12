using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class OptionValueConfiguration : IEntityTypeConfiguration<OptionValue>
    {
        public void Configure(EntityTypeBuilder<OptionValue> builder)
        {
            builder.HasKey(ov => new { ov.Id, ov.OptionId });
            builder.Property(ov => ov.Id).ValueGeneratedOnAdd();

            builder.HasMany<VariantValue>(ov => ov.VariantValues)
                   .WithOne(vv => vv.OptionValue)
                   .HasForeignKey(vv => new { vv.OptionValueId, vv.OptionId });


        }
    }
}

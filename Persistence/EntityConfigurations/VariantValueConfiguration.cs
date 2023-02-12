using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class VariantValueConfiguration : IEntityTypeConfiguration<VariantValue>
    {
        public void Configure(EntityTypeBuilder<VariantValue> builder)
        {
            builder.HasKey(vv => new { vv.ProductId, vv.VariantId, vv.OptionId});
        }
    }
}

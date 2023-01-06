using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(os => os.Id);

            builder.HasMany<Order>(os => os.Orders)
                  .WithOne(o => o.OrderStatus)
                  .HasForeignKey(o => o.OrderStatusId);
        }
    }
}

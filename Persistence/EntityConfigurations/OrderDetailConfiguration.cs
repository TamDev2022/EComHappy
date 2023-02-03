using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.Id);
            builder.Property(od => od.Id).ValueGeneratedOnAdd();


            builder.HasOne<Order>(od => od.Order)
              .WithOne(o => o.OrderDetail)
              .HasForeignKey<OrderDetail>(od => od.OrderId);
        }
    }
}

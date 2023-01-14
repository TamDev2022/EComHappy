using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class UserStatusConfiguration : IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> builder)
        {
            builder.HasKey(us => us.Id);
            builder.Property(us => us.Id).ValueGeneratedOnAdd();

        }
    }
}

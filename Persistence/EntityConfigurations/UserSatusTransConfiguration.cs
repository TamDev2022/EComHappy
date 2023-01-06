using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class UserSatusTransConfiguration : IEntityTypeConfiguration<UserStatusTrans>
    {
        public void Configure(EntityTypeBuilder<UserStatusTrans> builder)
        {
            builder.HasKey(ut => new { ut.UserId, ut.StatusId });
        }
    }
}

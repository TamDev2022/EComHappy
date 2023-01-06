﻿using System;
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

            builder.HasMany<UserStatusTrans>(us => us.UserStatusTrans)
                  .WithOne(ut => ut.UserStatus)
                  .HasForeignKey(ut => ut.StatusId);
        }
    }
}

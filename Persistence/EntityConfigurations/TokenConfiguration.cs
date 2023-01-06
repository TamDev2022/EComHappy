using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne<User>(t => t.User)
                .WithOne(u => u.Token)
                .HasForeignKey<Token>(t => t.UserId);

        }
    }
}

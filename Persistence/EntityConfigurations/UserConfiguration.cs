
namespace Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");


            builder.HasMany<UserStatusTrans>(u => u.UserStatusTrans)
                   .WithOne(ut => ut.User)
                   .HasForeignKey(ut => ut.UserId);

            builder.HasMany<Order>(u => u.Orders)
                  .WithOne(o => o.User)
                  .HasForeignKey(o => o.UserId);

        }
    }
}


namespace Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");


            builder.HasMany<Order>(u => u.Orders)
                  .WithOne(o => o.User)
                  .HasForeignKey(o => o.UserId);

            builder.HasOne<UserStatus>(u => u.UserStatus)
                   .WithOne(us => us.User)
                   .HasForeignKey<User>(u => u.StatusId);
        }
    }
}

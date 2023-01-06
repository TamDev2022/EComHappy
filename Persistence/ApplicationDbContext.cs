using Domain.Entities;
using Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Brand> Brand { get; set; }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductItem> ProductItem { get; set; }
        public DbSet<ProductMedia> ProductMedia { get; set; }

        public DbSet<Role> Role { get; set; }
        public DbSet<Token> Token { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        public DbSet<UserStatusTrans> UserStatusTrans { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.ApplyConfiguration(new BrandConfiguration());

            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new CartItemConfiguration());

            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new OrderStatusConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductItemConfiguration());
            builder.ApplyConfiguration(new ProductMediaConfiguration());

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.ApplyConfiguration(new TokenConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserStatusConfiguration());
            builder.ApplyConfiguration(new UserSatusTransConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Backend.Entities.Configuration;

namespace Project.Backend.Entities
{
    public class ProjectDBContext : IdentityDbContext<User, Role, Guid>
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> contextOptions) : base(contextOptions) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishSize> DishSizes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Resturant> Restuarants { get; set; }
        public DbSet<UserAddresses> UserAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ProjectDBContext).Assembly);
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new DishConfiguration());
            builder.ApplyConfiguration(new DishSizeConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ResturantConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserAddressesConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());


        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Backend.Entities.Configuration;

namespace Project.Backend.Entities
{
    public class ProjectDBContext : IdentityDbContext<User, Role, Guid>
    {
        //public ProjectDBContext(DbContextOptions contextOptions) : base(contextOptions) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishSize> DishSizes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Resturant> Restuarants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-K1HI8GRN\\SQLEXPRESS;Database=ProjectDB;Integrated Security=true;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new UserAddressesConfiguration());


        }
    }
}

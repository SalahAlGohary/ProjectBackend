using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Backend.Entities.Configuration;

namespace Project.Backend.Entities
{
    public class ProjectDBContext : IdentityDbContext<User, Role, Guid>
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> contextOptions) : base(contextOptions) { }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ProjectDBContext).Assembly);
            builder.ApplyConfiguration(new DishConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());


        }
    }
}

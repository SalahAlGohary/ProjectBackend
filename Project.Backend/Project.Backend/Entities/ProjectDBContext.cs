using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Backend.Entities.Configuration;

namespace Project.Backend.Entities
{
    public class ProjectDBContext : IdentityDbContext<User, Role, Guid>
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> contextOptions) : base(contextOptions) { }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<FoodRecipe> Recipes { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Collection> Categories { get; set; }
        public DbSet<DietType> Diets { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<FoodRecipeCollection> FoodRecipeCollections { get; set; }
        public DbSet<FoodRecipeCourse> FoodRecipeCourses { get; set; }
        public DbSet<DietType> DietTypes { get; set; }
        public DbSet<FoodRecipeDietType> FoodRecipeDietTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<FoodRecipeIngredient> FoodRecipeIngredients { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<FoodRecipeKeyword> FoodRecipeKeywords { get; set; }
        public DbSet<NutritionInfo> NutritionInfos { get; set; }
        public DbSet<FoodRecipeNutritionInfo> FoodRecipeNutritionInfos { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CVST0Q3\SQLEXPRESS;Initial Catalog=BBCDataset;Integrated Security=True;Trust Server Certificate=True");
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ProjectDBContext).Assembly);
            //builder.ApplyConfiguration(new RecipeConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfigurationsFromAssembly(typeof(ProjectDBContext).Assembly);
            builder.Entity<FoodRecipeCollection>()
            .HasKey(ri => new { ri.RecipeId, ri.CollectionId });
            builder.Entity<FoodRecipeCourse>()
           .HasKey(ri => new { ri.RecipeId, ri.CourseId });
            builder.Entity<FoodRecipeDietType>()
           .HasKey(ri => new { ri.RecipeId, ri.DietTypeId });
            builder.Entity<FoodRecipeKeyword>()
           .HasKey(ri => new { ri.RecipeId, ri.KeywordId });
            builder.Entity<FoodRecipeNutritionInfo>()
           .HasKey(ri => new { ri.RecipeId, ri.NutritionInfoId });
            builder.Entity<FoodRecipeIngredient>()
           .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            builder.Entity<FoodRecipe>()
                .HasOne(ri => ri.Cuisine)
                .WithMany(r => r.Recipes)
                .HasForeignKey(ri => ri.CuisineId);

            builder.Entity<FoodRecipeCollection>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.FoodRecipeCollections)
                .HasForeignKey(ri => ri.RecipeId);
            builder.Entity<FoodRecipeCollection>()
                .HasOne(ri => ri.Collection)
                .WithMany(r => r.FoodRecipeCollections)
                .HasForeignKey(ri => ri.CollectionId);

            builder.Entity<FoodRecipeCourse>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.FoodRecipeCourses)
                .HasForeignKey(ri => ri.RecipeId);
            builder.Entity<FoodRecipeCourse>()
                .HasOne(ri => ri.Course)
                .WithMany(r => r.FoodRecipeCourses)
                .HasForeignKey(ri => ri.CourseId);

            builder.Entity<FoodRecipeDietType>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.FoodRecipeDietTypes)
                .HasForeignKey(ri => ri.RecipeId);
            builder.Entity<FoodRecipeDietType>()
                .HasOne(ri => ri.DietType)
                .WithMany(r => r.FoodRecipeDietTypes)
                .HasForeignKey(ri => ri.DietTypeId);

            builder.Entity<FoodRecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.FoodRecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);
            builder.Entity<FoodRecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(r => r.FoodRecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            builder.Entity<FoodRecipeKeyword>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.FoodRecipeKeywords)
                .HasForeignKey(ri => ri.RecipeId);
            builder.Entity<FoodRecipeKeyword>()
                .HasOne(ri => ri.Keyword)
                .WithMany(r => r.FoodRecipeKeywords)
                .HasForeignKey(ri => ri.KeywordId);

            builder.Entity<FoodRecipeNutritionInfo>()
               .HasOne(ri => ri.Recipe)
               .WithMany(r => r.FoodRecipeNutritionInfos)
               .HasForeignKey(ri => ri.RecipeId);
            builder.Entity<FoodRecipeNutritionInfo>()
           .HasOne(ri => ri.NutritionInfo)
           .WithMany(r => r.FoodRecipeNutritionInfos)
           .HasForeignKey(ri => ri.NutritionInfoId);


        }
    }
}

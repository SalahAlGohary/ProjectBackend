using Microsoft.EntityFrameworkCore;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Services;
using Project.Backend.Entities;
using Project.Backend.Repositories;
using Project.Backend.Services;
using System.Reflection;
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<ProjectDBContext>(options =>
options.UseSqlServer(
           configuration.GetConnectionString("ProjectBackendConnectionString")));
builder.Services.AddTransient<ImageController>();
builder.Services.AddTransient(typeof(IAddressRepository), typeof(AddressRepository));
builder.Services.AddTransient(typeof(IDishRepository), typeof(DishRepository));
builder.Services.AddTransient(typeof(IDietRepository), typeof(DietRepository));
builder.Services.AddTransient(typeof(ICourseRepository), typeof(CourseRepository));
builder.Services.AddTransient(typeof(ICuisineRepository), typeof(CuisineRepository));
builder.Services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));
builder.Services.AddTransient(typeof(IFavoriteRepository), typeof(FavoriteRepository));
builder.Services.AddTransient(typeof(IRecommendationRepository), typeof(RecommendationRepository));
builder.Services.AddTransient(typeof(IAddressService), typeof(AddressService));
builder.Services.AddTransient(typeof(ICategoryService), typeof(CategoryService));
builder.Services.AddTransient(typeof(ICourseService), typeof(CourseService));
builder.Services.AddTransient(typeof(ICuisineService), typeof(CuisineService));
builder.Services.AddTransient(typeof(IDietService), typeof(DietService));
builder.Services.AddTransient(typeof(IDishService), typeof(DishService));
builder.Services.AddTransient(typeof(IFavoriteService), typeof(FavoriteService));
builder.Services.AddTransient(typeof(IRecommendationService), typeof(RecommendationService));


builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectBackend.Api v1"));


app.Run();

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
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IDishRepository, DishRepository>();
builder.Services.AddTransient<IDietRepository, DietRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<ICuisineRepository, CuisineRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddTransient<IRecommendationRepository, RecommendationRepository>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<ICuisineService, CuisineService>();
builder.Services.AddTransient<IDietService, DietService>();
builder.Services.AddTransient<IDishService, DishService>();
builder.Services.AddTransient<IFavoriteService, FavoriteService>();
builder.Services.AddTransient<IRecommendationService, RecommendationService>();


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

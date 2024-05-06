using Microsoft.EntityFrameworkCore;
using Project.Backend.Entities;
using Project.Backend.Repositories;
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
builder.Services.AddTransient<AddressRepository>();
builder.Services.AddTransient<DishRepository>();
builder.Services.AddTransient<DietRepository>();
builder.Services.AddTransient<CourseRepository>();
builder.Services.AddTransient<CuisineRepository>();
builder.Services.AddTransient<CategoryRepository>();
builder.Services.AddTransient<FavoriteRepository>();
builder.Services.AddTransient<RecommendationRepository>();

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

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NativeBackend.Application.Common.Models.Identity;
using Project.Backend.Contracts;
using Project.Backend.Contracts.Identity;
using Project.Backend.Contracts.Infrastructure;
using Project.Backend.Contracts.Services;
using Project.Backend.Entities;
using Project.Backend.Repositories;
using Project.Backend.Services;
using Project.Backend.Services.Identity;
using Project.Backend.Services.ImageService;
using System.Reflection;
using System.Text;
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    c.AddSecurityDefinition("CustomToken", new OpenApiSecurityScheme
    {
        Name = "X-Custom-Token",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Enter your token in the text input below."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "CustomToken"
                }
            },
            new string[] {}
        }
    });
});

//builder.Services.AddTransient<HttpContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<ProjectDBContext>(options =>
options.UseSqlServer(
           configuration.GetConnectionString("ProjectBackendConnectionString"))
);

builder.Services.AddTransient<ImageController>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
builder.Services.AddTransient<IDietRepository, DietTypeRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<ICuisineRepository, CuisineRepository>();
builder.Services.AddTransient<ICollectionRepository, CollectionRepository>();
builder.Services.AddTransient<IKeywordRepository, KeywordRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddTransient<IRecommendationRepository, RecommendationRepository>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<ICollectionService, CollectionService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<ICuisineService, CuisineService>();
builder.Services.AddTransient<IDietService, DietService>();
builder.Services.AddTransient<IRecipeService, RecipeService>();
builder.Services.AddTransient<IFavoriteService, FavoriteService>();
builder.Services.AddTransient<IRecommendationService, RecommendationService>();
builder.Services.AddTransient<IKeywordService, KeywordService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IFormFileImagesService, FormFileImagesService>();
builder.Services.AddTransient<IOAuthTokenUserRepository, OAuthTokenUserRepository>();

builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ProjectDBContext>().AddDefaultTokenProviders();
builder.Services.AddSingleton<IWebHostEnvironment>(builder.Environment);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = configuration["JwtSettings:Issuer"],
            ValidAudience = configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
        };
    });

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
app.UseMiddleware<CustomTokenMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectBackend.Api v1"));


app.Run();

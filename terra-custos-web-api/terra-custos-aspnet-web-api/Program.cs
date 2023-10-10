using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using terra_custos_aspnet_web_api.DbContexts;
using terra_custos_aspnet_web_api.IRepositories;
using terra_custos_aspnet_web_api.IService;
using terra_custos_aspnet_web_api.Repositories;
using terra_custos_aspnet_web_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TerraCustosContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TerraCustos")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<TerraCustosContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000", "http://127.0.0.1:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

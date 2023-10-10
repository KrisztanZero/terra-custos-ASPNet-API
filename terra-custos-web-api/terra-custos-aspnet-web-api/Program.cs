using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using terra_custos_aspnet_web_api.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TerraCustosContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TerraCustos")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<TerraCustosContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

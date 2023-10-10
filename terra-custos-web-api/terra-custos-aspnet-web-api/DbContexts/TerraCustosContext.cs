using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using terra_custos_aspnet_web_api.Models;

namespace terra_custos_aspnet_web_api.DbContexts
{
    public class TerraCustosContext : IdentityDbContext
    {
        public TerraCustosContext(DbContextOptions option) : base(option) { }
        public DbSet<User> AppUsers { get; set; }
    }
}
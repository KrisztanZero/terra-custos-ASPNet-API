using Microsoft.EntityFrameworkCore;
using terra_custos_aspnet_web_api.DbContexts;
using terra_custos_aspnet_web_api.IRepositories;
using terra_custos_aspnet_web_api.Models;

namespace terra_custos_aspnet_web_api.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TerraCustosContext context) : base(context)
        {
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) 
            {  
                throw new ArgumentNullException(nameof(username), "Username cannot be null or empty");
            }
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.UserName == username);
            return user ?? throw new InvalidOperationException($"Username {username} not found");
        }
    }
}
using terra_custos_aspnet_web_api.Models;

namespace terra_custos_aspnet_web_api.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByNameAsync(string username);
    }
}

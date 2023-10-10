using terra_custos_aspnet_web_api.Models;

namespace terra_custos_aspnet_web_api.IService
{
    public interface IUserService : IGenericService<User>
    {
        Task<User> GetByNameAsync(string username);
    }
}
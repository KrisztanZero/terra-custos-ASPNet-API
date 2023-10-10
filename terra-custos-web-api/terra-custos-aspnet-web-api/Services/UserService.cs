using terra_custos_aspnet_web_api.IRepositories;
using terra_custos_aspnet_web_api.IService;
using terra_custos_aspnet_web_api.Models;

namespace terra_custos_aspnet_web_api.Services
{
    public class UserService : GenericService<User> , IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IGenericRepository<User> repository, IUserRepository userRepository) : base(repository) 
        {
            _userRepository = userRepository;
        }

        public Task<User> GetByNameAsync(string name)
        {
            return  _userRepository.GetUserByNameAsync(name);
        }
    }
}
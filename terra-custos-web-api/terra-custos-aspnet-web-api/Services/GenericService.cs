using terra_custos_aspnet_web_api.IRepositories;
using terra_custos_aspnet_web_api.IService;

namespace terra_custos_aspnet_web_api.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<T> CreateAsync(T entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            return await _repository.UpdateAsync(id, entity);
        }
        public async Task<bool> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

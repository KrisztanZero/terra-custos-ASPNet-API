using terra_custos_aspnet_web_api.Models;

namespace terra_custos_aspnet_web_api.IService
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(string id, T entity);
        Task<bool> DeleteAsync(string id);
    }
}

using Microsoft.EntityFrameworkCore;
using terra_custos_aspnet_web_api.IRepositories;

namespace terra_custos_aspnet_web_api.Repositories
{
    public abstract class GenericRepository<T, TContext> : IGenericRepository<T> where T : class where TContext : DbContext
    {
        protected readonly TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id) ?? throw new InvalidOperationException($"Entity with ID: {id} not found");
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(string id, T updateEntity)
        {
            var existingEntity = await _context
                .Set<T>()
                .FindAsync( id) ?? throw new InvalidOperationException($"Entity with ID: {id} not exist");

            if (updateEntity == null)
            {
                throw new ArgumentNullException(nameof(updateEntity),"UpdateEntity cannot be null");
            }

            _context.Entry<T>(existingEntity).CurrentValues.SetValues(updateEntity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) return false;
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

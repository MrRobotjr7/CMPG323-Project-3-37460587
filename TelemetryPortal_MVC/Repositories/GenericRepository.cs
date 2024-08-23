using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Data;

namespace TelemetryPortal_MVC.Repositories
{
  
 
        public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            protected readonly TechtrendsContext _context;
            private readonly DbSet<T> _dbSet;

            public GenericRepository(TechtrendsContext context)
            {
                _context = context;
                _dbSet = _context.Set<T>();
            }

            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }

            public async Task<T> GetByIdAsync(Guid id)
            {
                return await _dbSet.FindAsync(id);
            }

            public async Task AddAsync(T entity)
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(T entity)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(Guid id)
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<bool> ExistsAsync(Guid id)
            {
                return await _dbSet.FindAsync(id) != null;
            }
        }





}


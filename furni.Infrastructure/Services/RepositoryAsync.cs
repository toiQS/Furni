using furni.Entities;
using Microsoft.EntityFrameworkCore;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Data;

namespace furni.Infrastructure.Services
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _dbSet = _context.Set<T>();
        }

        public async Task<IList<T>> GetAsync()
        {
            try
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                return await _dbSet.AsNoTracking().FirstAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateAsync(T entity)
        {
            if (entity == null) return false;
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null) return false;
            try
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null || entity.GetType() != typeof(T)) return false;
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

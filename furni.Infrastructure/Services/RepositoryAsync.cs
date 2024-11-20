using furni.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using furni.Infrastructure.IServices;
using furni.Infrastructure.Data;

namespace furni.Infrastructure.Services
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public DbSet<T> Table { get; set; }

        public RepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            Table = _context.Set<T>();
        }

        public async Task<IList<T>> GetAsync()
        {
            try
            {
                return await Table.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await Table.AsNoTracking().FirstAsync(x => x.Id == id);
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
                await Table.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var getData = await Table.FindAsync(id);
                if (getData == null) return false;
                Table.Remove(getData);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            try
            {
                var getData = await Table.FindAsync(id);
                if (getData == null) return false;
                getData = entity;
                Table.Update(getData);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Entities.DataTransferObject;
using Entities.Models;
using Repositories.Abstract;
using Repositories.Context;

namespace Repositories.Concrete
{
    public class GenericRepository<T> where T : class
    {
        protected readonly RentACarDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(RentACarDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}


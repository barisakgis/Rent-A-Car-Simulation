//using Rent_A_Car_Simulation.Data;
//using Rent_A_Car_Simulation.Repository_Interfaces;

//namespace Rent_A_Car_Simulation.Repositories
//{
//    public class GenericRepository<T> : IGenericRepository<T> where T : class
//    {
//        private readonly RentACarDbContext _context;
//        public GenericRepository(RentACarDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<T> GetByIdAsync(int id)
//        {
//            return await _context.Set<T>().FindAsync(id);
//        }

//        public async Task<List<T>> GetAllAsync()
//        {
//            return await _context.Set<T>().ToListAsync();
//        }

//        public async Task AddAsync(T entity)
//        {
//            await _context.Set<T>().AddAsync(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(T entity)
//        {
//            _context.Set<T>().Update(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var entity = await _context.Set<T>().FindAsync(id);
//            if (entity != null)
//            {
//                _context.Set<T>().Remove(entity);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }

//}


using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Simulation.Data;
using Rent_A_Car_Simulation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_Simulation.Repositories
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


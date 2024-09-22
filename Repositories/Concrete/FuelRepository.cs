using Microsoft.EntityFrameworkCore;
using Entities.DataTransferObject;
using Entities.Models;
using Repositories.Abstract;
using Repositories.Context;

namespace Repositories.Concrete
{
    public class FuelRepository : GenericRepository<Fuel>, IFuelRepository
    {
        public FuelRepository(RentACarDbContext context) : base(context) { }

        public async Task<List<Fuel>> GetAllFuelsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Fuel> GetFuelByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<List<Fuel>> GetFuelsByNameContainsAsync(string name)
        {
            return await _dbSet.Where(f => f.Name.Contains(name)).ToListAsync();
        }
    }
}

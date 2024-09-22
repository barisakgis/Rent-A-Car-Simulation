using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Simulation.Data;
using Rent_A_Car_Simulation.Models;
using Rent_A_Car_Simulation.Repository_Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rent_A_Car_Simulation.Repositories
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

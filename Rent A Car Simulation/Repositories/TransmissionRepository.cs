using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Simulation.Data;
using Rent_A_Car_Simulation.Models;
using Rent_A_Car_Simulation.Repository_Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rent_A_Car_Simulation.Repositories
{
    public class TransmissionRepository : GenericRepository<Transmission>, ITransmissionRepository
    {
        public TransmissionRepository(RentACarDbContext context) : base(context) { }

        public async Task<List<Transmission>> GetAllTransmissionsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Transmission> GetTransmissionByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<List<Transmission>> GetTransmissionsByNameContainsAsync(string name)
        {
            return await _dbSet.Where(t => t.Name.Contains(name)).ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Entities.DataTransferObject;
using Entities.Models;
using Repositories.Abstract;
using Repositories.Context;

namespace Repositories.Concrete
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

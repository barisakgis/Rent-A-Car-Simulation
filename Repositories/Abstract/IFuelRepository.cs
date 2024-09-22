using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Abstract
{
    public interface IFuelRepository : IGenericRepository<Fuel>
    {
        Task<List<Fuel>> GetAllFuelsAsync();
        Task<Fuel> GetFuelByIdAsync(int id);
        Task<List<Fuel>> GetFuelsByNameContainsAsync(string name);
    }
}


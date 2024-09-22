using Rent_A_Car_Simulation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rent_A_Car_Simulation.Repository_Interfaces
{
    public interface IFuelRepository : IGenericRepository<Fuel>
    {
        Task<List<Fuel>> GetAllFuelsAsync();
        Task<Fuel> GetFuelByIdAsync(int id);
        Task<List<Fuel>> GetFuelsByNameContainsAsync(string name);
    }
}


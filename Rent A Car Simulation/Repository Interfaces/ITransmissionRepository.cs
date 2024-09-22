using Rent_A_Car_Simulation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rent_A_Car_Simulation.Repository_Interfaces
{
    public interface ITransmissionRepository : IGenericRepository<Transmission>
    {
        Task<List<Transmission>> GetAllTransmissionsAsync();
        Task<Transmission> GetTransmissionByIdAsync(int id);
        Task<List<Transmission>> GetTransmissionsByNameContainsAsync(string name);
    }
}

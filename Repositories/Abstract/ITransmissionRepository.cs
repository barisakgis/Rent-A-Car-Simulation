using Entities.Models;
namespace Repositories.Abstract
{
    public interface ITransmissionRepository : IGenericRepository<Transmission>
    {
        Task<List<Transmission>> GetAllTransmissionsAsync();
        Task<Transmission> GetTransmissionByIdAsync(int id);
        Task<List<Transmission>> GetTransmissionsByNameContainsAsync(string name);
    }
}

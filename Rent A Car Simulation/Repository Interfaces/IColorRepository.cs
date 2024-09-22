using Rent_A_Car_Simulation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rent_A_Car_Simulation.Repository_Interfaces
{
    public interface IColorRepository : IGenericRepository<Color>
    {
        Task<List<Color>> GetAllColorsAsync();
        Task<Color> GetColorByIdAsync(int id);
        Task<List<Color>> GetColorsByNameContainsAsync(string name);


        // Eklenen metotlar
        Task AddAsync(Color color);
        Task UpdateAsync(Color color);
        Task DeleteAsync(int id);
    }
}

using Rent_A_Car_Simulation.DTOs; // ColorDto için gerekli namespace
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rent_A_Car_Simulation.Service_Interfaces
{
    public interface IColorService
    {
        Task<List<ColorDto>> GetAllColorsAsync();
        Task<ColorDto?> GetColorByIdAsync(int id);
        Task AddColorAsync(ColorDto colorDto);
        Task UpdateColorAsync(ColorDto colorDto);
        Task DeleteColorAsync(int id);
    }
}

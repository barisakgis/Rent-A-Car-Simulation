 
using Entities.DataTransferObject;

namespace Services.Abstract
{
    public interface IFuelService
    {
        Task<List<FuelDto>> GetAllFuelsAsync();
        Task<FuelDto?> GetFuelByIdAsync(int id);
        Task AddFuelAsync(FuelDto fuelDto);
        Task UpdateFuelAsync(FuelDto fuelDto);
        Task DeleteFuelAsync(int id);
    }
}

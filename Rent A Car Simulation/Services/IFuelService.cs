using Rent_A_Car_Simulation.DTOs;
using Rent_A_Car_Simulation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFuelService
{
    Task<List<FuelDto>> GetAllFuelsAsync();
    Task<FuelDto?> GetFuelByIdAsync(int id);
    Task AddFuelAsync(FuelDto fuelDto);
    Task UpdateFuelAsync(FuelDto fuelDto);
    Task DeleteFuelAsync(int id);
}

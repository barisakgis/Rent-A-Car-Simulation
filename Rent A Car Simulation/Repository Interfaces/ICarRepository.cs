﻿using Rent_A_Car_Simulation.DTOs;
using Rent_A_Car_Simulation.Models;
 

namespace Rent_A_Car_Simulation.Repository_Interfaces
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<List<CarDetailDto>> GetAllDetailsAsync();
        Task<List<CarDetailDto>> GetDetailsByFuelIdAsync(int fuelId);
        Task<List<CarDetailDto>> GetDetailsByColorIdAsync(int colorId);
        Task<List<CarDetailDto>> GetDetailsByPriceRangeAsync(double min, double max);
        Task<List<CarDetailDto>> GetDetailsByBrandNameContainsAsync(string brandName);
        Task<List<CarDetailDto>> GetDetailsByModelNameContainsAsync(string modelName);
        Task<CarDetailDto> GetDetailByIdAsync(int id);
        Task<List<CarDetailDto>> GetDetailsByKilometerRangeAsync(int min, int max);
    }

    


}

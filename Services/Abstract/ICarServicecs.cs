﻿using Entities.DataTransferObject; 

namespace Services.Abstract
{

    public interface ICarService
    {
        Task<List<CarDetailDto>> GetAllDetailsAsync();
        Task<CarDetailDto?> GetDetailByIdAsync(int id);
        Task<List<CarDetailDto>> GetAllDetailsByFuelIdAsync(int fuelId);
        Task<List<CarDetailDto>> GetAllDetailsByColorIdAsync(int colorId);
        Task<List<CarDetailDto>> GetAllDetailsByPriceRangeAsync(double min, double max);
        Task<List<CarDetailDto>> GetAllDetailsByBrandNameContainsAsync(string brandName);
        Task<List<CarDetailDto>> GetAllDetailsByModelNameContainsAsync(string modelName);
        Task<List<CarDetailDto>> GetAllDetailsByKilometerRangeAsync(int min, int max);

        // Araç ekleme, güncelleme ve silme işlemleri
        Task AddCarAsync(CarDto carDto);
        Task UpdateCarAsync(CarDto carDto);
        Task DeleteCarAsync(int id);
    }

}

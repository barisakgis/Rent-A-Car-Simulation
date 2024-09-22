using Rent_A_Car_Simulation.DTOs;
using Rent_A_Car_Simulation.Repository_Interfaces; 
using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Rent_A_Car_Simulation.Models;

namespace Rent_A_Car_Simulation.Services
{

    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        // Tüm araçların detaylarını döndürür
        public async Task<List<CarDetailDto>> GetAllDetailsAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            return _mapper.Map<List<CarDetailDto>>(cars);
        }

        // Belirli bir ID'ye sahip aracın detaylarını döndürür
        public async Task<CarDetailDto?> GetDetailByIdAsync(int id)
        {
            var car = await _carRepository.GetDetailByIdAsync(id);
            return _mapper.Map<CarDetailDto>(car);
        }

        // Yakıt türüne göre araçları filtreleyerek döndürür
        public async Task<List<CarDetailDto>> GetAllDetailsByFuelIdAsync(int fuelId)
        {
            var cars = await _carRepository.GetDetailsByFuelIdAsync(fuelId);
            return _mapper.Map<List<CarDetailDto>>(cars);
        }

        // Renk türüne göre araçları filtreleyerek döndürür
        public async Task<List<CarDetailDto>> GetAllDetailsByColorIdAsync(int colorId)
        {
            var cars = await _carRepository.GetDetailsByColorIdAsync(colorId);
            return _mapper.Map<List<CarDetailDto>>(cars);
        }

        // Belirtilen fiyat aralığındaki araçları filtreleyerek döndürür
        public async Task<List<CarDetailDto>> GetAllDetailsByPriceRangeAsync(double min, double max)
        {
            var cars = await _carRepository.GetDetailsByPriceRangeAsync(min, max);
            return _mapper.Map<List<CarDetailDto>>(cars);
        }

        // Marka adına göre araçları filtreleyerek döndürür
        public async Task<List<CarDetailDto>> GetAllDetailsByBrandNameContainsAsync(string brandName)
        {
            var cars = await _carRepository.GetDetailsByBrandNameContainsAsync(brandName);
            return _mapper.Map<List<CarDetailDto>>(cars);
        }

        // Model adına göre araçları filtreleyerek döndürür
        public async Task<List<CarDetailDto>> GetAllDetailsByModelNameContainsAsync(string modelName)
        {
            var cars = await _carRepository.GetDetailsByModelNameContainsAsync(modelName);
            return _mapper.Map<List<CarDetailDto>>(cars);
        }

        // Kilometre aralığına göre araçları filtreleyerek döndürür
        public async Task<List<CarDetailDto>> GetAllDetailsByKilometerRangeAsync(int min, int max)
        {
            var cars = await _carRepository.GetDetailsByKilometerRangeAsync(min, max);
            return _mapper.Map<List<CarDetailDto>>(cars);
        }

        // Araç ekleme, güncelleme ve silme işlemleri de yapılabilir, örneğin:
        public async Task AddCarAsync(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await _carRepository.AddAsync(car);
        }

        public async Task UpdateCarAsync(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await _carRepository.UpdateAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteAsync(id);
        }
    }


}

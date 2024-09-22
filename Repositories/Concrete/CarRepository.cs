using Microsoft.EntityFrameworkCore;
using Entities.DataTransferObject;
using Entities.Models;
using Repositories.Abstract;
using Repositories.Context;

namespace Repositories.Concrete
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(RentACarDbContext context) : base(context) { }

        public async Task<List<CarDetailDto>> GetAllDetailsAsync()
        {
            return await _context.Cars
                .Select(car => new CarDetailDto
                {
                    Id = car.Id,
                    FuelName = car.Fuel.Name,
                    TransmissionName = car.Transmission.Name,
                    ColorName = car.Color.Name,
                    CarState = car.CarState,
                    KiloMeter = car.KiloMeter,
                    ModelYear = car.ModelYear,
                    Plate = car.Plate,
                    BrandName = car.BrandName,
                    ModelName = car.ModelName,
                    DailyPrice = car.DailyPrice
                }).ToListAsync();
        }

        public async Task<CarDetailDto> GetDetailByIdAsync(int id)
        {
            return await _context.Cars
                .Where(car => car.Id == id)
                .Select(car => new CarDetailDto
                {
                    Id = car.Id,
                    FuelName = car.Fuel.Name,
                    TransmissionName = car.Transmission.Name,
                    ColorName = car.Color.Name,
                    CarState = car.CarState,
                    KiloMeter = car.KiloMeter,
                    ModelYear = car.ModelYear,
                    Plate = car.Plate,
                    BrandName = car.BrandName,
                    ModelName = car.ModelName,
                    DailyPrice = car.DailyPrice
                }).FirstOrDefaultAsync();
        }

        public async Task<List<CarDetailDto>> GetDetailsByFuelIdAsync(int fuelId)
        {
            return await _context.Cars
                .Where(car => car.FuelId == fuelId)
                .Select(car => new CarDetailDto
                {
                    Id = car.Id,
                    FuelName = car.Fuel.Name,
                    TransmissionName = car.Transmission.Name,
                    ColorName = car.Color.Name,
                    CarState = car.CarState,
                    KiloMeter = car.KiloMeter,
                    ModelYear = car.ModelYear,
                    Plate = car.Plate,
                    BrandName = car.BrandName,
                    ModelName = car.ModelName,
                    DailyPrice = car.DailyPrice
                }).ToListAsync();
        }

        public async Task<List<CarDetailDto>> GetDetailsByColorIdAsync(int colorId)
        {
            return await _context.Cars
                .Where(car => car.ColorId == colorId)
                .Select(car => new CarDetailDto
                {
                    Id = car.Id,
                    FuelName = car.Fuel.Name,
                    TransmissionName = car.Transmission.Name,
                    ColorName = car.Color.Name,
                    CarState = car.CarState,
                    KiloMeter = car.KiloMeter,
                    ModelYear = car.ModelYear,
                    Plate = car.Plate,
                    BrandName = car.BrandName,
                    ModelName = car.ModelName,
                    DailyPrice = car.DailyPrice
                }).ToListAsync();
        }

        public async Task<List<CarDetailDto>> GetDetailsByPriceRangeAsync(double min, double max)
        {
            return await _context.Cars
                .Where(car => car.DailyPrice >= min && car.DailyPrice <= max)
                .Select(car => new CarDetailDto
                {
                    Id = car.Id,
                    FuelName = car.Fuel.Name,
                    TransmissionName = car.Transmission.Name,
                    ColorName = car.Color.Name,
                    CarState = car.CarState,
                    KiloMeter = car.KiloMeter,
                    ModelYear = car.ModelYear,
                    Plate = car.Plate,
                    BrandName = car.BrandName,
                    ModelName = car.ModelName,
                    DailyPrice = car.DailyPrice
                }).ToListAsync();
        }

        public async Task<List<CarDetailDto>> GetDetailsByBrandNameContainsAsync(string brandName)
        {
            return await _context.Cars
                .Where(car => car.BrandName.Contains(brandName))
                .Select(car => new CarDetailDto
                {
                    Id = car.Id,
                    FuelName = car.Fuel.Name,
                    TransmissionName = car.Transmission.Name,
                    ColorName = car.Color.Name,
                    CarState = car.CarState,
                    KiloMeter = car.KiloMeter,
                    ModelYear = car.ModelYear,
                    Plate = car.Plate,
                    BrandName = car.BrandName,
                    ModelName = car.ModelName,
                    DailyPrice = car.DailyPrice
                }).ToListAsync();
        }

        public async Task<List<CarDetailDto>> GetDetailsByModelNameContainsAsync(string modelName)
        {
            return await _context.Cars
                .Where(car => car.ModelName.Contains(modelName))
                .Select(car => new CarDetailDto
                {
                    Id = car.Id,
                    FuelName = car.Fuel.Name,
                    TransmissionName = car.Transmission.Name,
                    ColorName = car.Color.Name,
                    CarState = car.CarState,
                    KiloMeter = car.KiloMeter,
                    ModelYear = car.ModelYear,
                    Plate = car.Plate,
                    BrandName = car.BrandName,
                    ModelName = car.ModelName,
                    DailyPrice = car.DailyPrice
                }).ToListAsync();
        }

        public async Task<List<CarDetailDto>> GetDetailsByKilometerRangeAsync(int min, int max)
        {
            return await _context.Cars
                .Where(car => car.KiloMeter >= min && car.KiloMeter <= max)
                .Select(car => new CarDetailDto
                {
                    Id = car.Id,
                    FuelName = car.Fuel.Name,
                    TransmissionName = car.Transmission.Name,
                    ColorName = car.Color.Name,
                    CarState = car.CarState,
                    KiloMeter = car.KiloMeter,
                    ModelYear = car.ModelYear,
                    Plate = car.Plate,
                    BrandName = car.BrandName,
                    ModelName = car.ModelName,
                    DailyPrice = car.DailyPrice
                }).ToListAsync();
        }
    }
}


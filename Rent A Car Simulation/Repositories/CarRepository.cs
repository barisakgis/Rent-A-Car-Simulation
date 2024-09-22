//using Microsoft.EntityFrameworkCore;
//using Rent_A_Car_Simulation.Data;
//using Rent_A_Car_Simulation.DTOs;
//using Rent_A_Car_Simulation.Models;
//using Rent_A_Car_Simulation.Repository_Interfaces;

//namespace Rent_A_Car_Simulation.Repositories
//{
//    public class CarRepository : GenericRepository<Car>, ICarRepository
//    {
//        private readonly RentACarDbContext _context;

//        public CarRepository(RentACarDbContext context) : base(context)
//        {
//            _context = context;
//        }

//        // Tüm arabaların detaylarını getiren metod
//        public async Task<List<CarDetailDto>> GetAllDetailsAsync()
//        {
//            var result = from car in _context.Cars
//                         join color in _context.Colors on car.ColorId equals color.Id
//                         join fuel in _context.Fuels on car.FuelId equals fuel.Id
//                         join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
//                         select new CarDetailDto
//                         {
//                             Id = car.Id,
//                             FuelName = fuel.Name,
//                             TransmissionName = transmission.Name,
//                             ColorName = color.Name,
//                             CarState = car.CarState,
//                             KiloMeter = car.KiloMeter,
//                             ModelYear = car.ModelYear,
//                             Plate = car.Plate,
//                             BrandName = car.BrandName,
//                             ModelName = car.ModelName,
//                             DailyPrice = car.DailyPrice
//                         };

//            return await result.ToListAsync();
//        }

//        // FuelId'ye göre araba detaylarını getiren metod
//        public async Task<List<CarDetailDto>> GetAllDetailsByFuelIdAsync(int fuelId)
//        {
//            var result = from car in _context.Cars
//                         join color in _context.Colors on car.ColorId equals color.Id
//                         join fuel in _context.Fuels on car.FuelId equals fuel.Id
//                         join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
//                         where car.FuelId == fuelId
//                         select new CarDetailDto
//                         {
//                             Id = car.Id,
//                             FuelName = fuel.Name,
//                             TransmissionName = transmission.Name,
//                             ColorName = color.Name,
//                             CarState = car.CarState,
//                             KiloMeter = car.KiloMeter,
//                             ModelYear = car.ModelYear,
//                             Plate = car.Plate,
//                             BrandName = car.BrandName,
//                             ModelName = car.ModelName,
//                             DailyPrice = car.DailyPrice
//                         };

//            return await result.ToListAsync();
//        }

//        // ColorId'ye göre araba detaylarını getiren metod
//        public async Task<List<CarDetailDto>> GetAllDetailsByColorIdAsync(int colorId)
//        {
//            var result = from car in _context.Cars
//                         join color in _context.Colors on car.ColorId equals color.Id
//                         join fuel in _context.Fuels on car.FuelId equals fuel.Id
//                         join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
//                         where car.ColorId == colorId
//                         select new CarDetailDto
//                         {
//                             Id = car.Id,
//                             FuelName = fuel.Name,
//                             TransmissionName = transmission.Name,
//                             ColorName = color.Name,
//                             CarState = car.CarState,
//                             KiloMeter = car.KiloMeter,
//                             ModelYear = car.ModelYear,
//                             Plate = car.Plate,
//                             BrandName = car.BrandName,
//                             ModelName = car.ModelName,
//                             DailyPrice = car.DailyPrice
//                         };

//            return await result.ToListAsync();
//        }

//        // Fiyat aralığına göre araba detaylarını getiren metod
//        public async Task<List<CarDetailDto>> GetAllDetailsByPriceRangeAsync(double min, double max)
//        {
//            var result = from car in _context.Cars
//                         join color in _context.Colors on car.ColorId equals color.Id
//                         join fuel in _context.Fuels on car.FuelId equals fuel.Id
//                         join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
//                         where car.DailyPrice >= min && car.DailyPrice <= max
//                         select new CarDetailDto
//                         {
//                             Id = car.Id,
//                             FuelName = fuel.Name,
//                             TransmissionName = transmission.Name,
//                             ColorName = color.Name,
//                             CarState = car.CarState,
//                             KiloMeter = car.KiloMeter,
//                             ModelYear = car.ModelYear,
//                             Plate = car.Plate,
//                             BrandName = car.BrandName,
//                             ModelName = car.ModelName,
//                             DailyPrice = car.DailyPrice
//                         };

//            return await result.ToListAsync();
//        }

//        // Marka adına göre filtreleme (contains) yapan metod
//        public async Task<List<CarDetailDto>> GetAllDetailsByBrandNameContainsAsync(string brandName)
//        {
//            var result = from car in _context.Cars
//                         join color in _context.Colors on car.ColorId equals color.Id
//                         join fuel in _context.Fuels on car.FuelId equals fuel.Id
//                         join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
//                         where car.BrandName.Contains(brandName)
//                         select new CarDetailDto
//                         {
//                             Id = car.Id,
//                             FuelName = fuel.Name,
//                             TransmissionName = transmission.Name,
//                             ColorName = color.Name,
//                             CarState = car.CarState,
//                             KiloMeter = car.KiloMeter,
//                             ModelYear = car.ModelYear,
//                             Plate = car.Plate,
//                             BrandName = car.BrandName,
//                             ModelName = car.ModelName,
//                             DailyPrice = car.DailyPrice
//                         };

//            return await result.ToListAsync();
//        }

//        // Model adına göre filtreleme (contains) yapan metod
//        public async Task<List<CarDetailDto>> GetAllDetailsByModelNameContainsAsync(string modelName)
//        {
//            var result = from car in _context.Cars
//                         join color in _context.Colors on car.ColorId equals color.Id
//                         join fuel in _context.Fuels on car.FuelId equals fuel.Id
//                         join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
//                         where car.ModelName.Contains(modelName)
//                         select new CarDetailDto
//                         {
//                             Id = car.Id,
//                             FuelName = fuel.Name,
//                             TransmissionName = transmission.Name,
//                             ColorName = color.Name,
//                             CarState = car.CarState,
//                             KiloMeter = car.KiloMeter,
//                             ModelYear = car.ModelYear,
//                             Plate = car.Plate,
//                             BrandName = car.BrandName,
//                             ModelName = car.ModelName,
//                             DailyPrice = car.DailyPrice
//                         };

//            return await result.ToListAsync();
//        }

//        // Kilometre aralığına göre filtreleme yapan metod
//        public async Task<List<CarDetailDto>> GetAllDetailsByKilometerRangeAsync(int min, int max)
//        {
//            var result = from car in _context.Cars
//                         join color in _context.Colors on car.ColorId equals color.Id
//                         join fuel in _context.Fuels on car.FuelId equals fuel.Id
//                         join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
//                         where car.KiloMeter >= min && car.KiloMeter <= max
//                         select new CarDetailDto
//                         {
//                             Id = car.Id,
//                             FuelName = fuel.Name,
//                             TransmissionName = transmission.Name,
//                             ColorName = color.Name,
//                             CarState = car.CarState,
//                             KiloMeter = car.KiloMeter,
//                             ModelYear = car.ModelYear,
//                             Plate = car.Plate,
//                             BrandName = car.BrandName,
//                             ModelName = car.ModelName,
//                             DailyPrice = car.DailyPrice
//                         };

//            return await result.ToListAsync();
//        }

//        // ID'ye göre araba detaylarını getiren metod
//        public async Task<CarDetailDto?> GetDetailByIdAsync(int id)
//        {
//            var result = from car in _context.Cars
//                         join color in _context.Colors on car.ColorId equals color.Id
//                         join fuel in _context.Fuels on car.FuelId equals fuel.Id
//                         join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
//                         where car.Id == id
//                         select new CarDetailDto
//                         {
//                             Id = car.Id,
//                             FuelName = fuel.Name,
//                             TransmissionName = transmission.Name,
//                             ColorName = color.Name,
//                             CarState = car.CarState,
//                             KiloMeter = car.KiloMeter,
//                             ModelYear = car.ModelYear,
//                             Plate = car.Plate,
//                             BrandName = car.BrandName,
//                             ModelName = car.ModelName,
//                             DailyPrice = car.DailyPrice
//                         };

//            return await result.FirstOrDefaultAsync();
//        }
//    }



//}

using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Simulation.Data;
using Rent_A_Car_Simulation.DTOs;
using Rent_A_Car_Simulation.Models;
using Rent_A_Car_Simulation.Repository_Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car_Simulation.Repositories
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


using Rent_A_Car_Simulation.DTOs;
using Rent_A_Car_Simulation.Models;
using Rent_A_Car_Simulation.Repository_Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FuelService : IFuelService
{
    private readonly IFuelRepository _fuelRepository;

    public FuelService(IFuelRepository fuelRepository)
    {
        _fuelRepository = fuelRepository;
    }

    public async Task<List<FuelDto>> GetAllFuelsAsync()
    {
        var fuels = await _fuelRepository.GetAllFuelsAsync();
        var fuelDtos = fuels.Select(f => new FuelDto { Id = f.Id, Name = f.Name }).ToList();
        return fuelDtos;
    }

    public async Task<FuelDto?> GetFuelByIdAsync(int id)
    {
        var fuel = await _fuelRepository.GetFuelByIdAsync(id);
        if (fuel == null) return null;

        return new FuelDto
        {
            Id = fuel.Id,
            Name = fuel.Name
        };
    }

    public async Task AddFuelAsync(FuelDto fuelDto)
    {
        var fuel = new Fuel
        {
            Name = fuelDto.Name
        };
        await _fuelRepository.AddAsync(fuel);
    }

    public async Task UpdateFuelAsync(FuelDto fuelDto)
    {
        var fuel = await _fuelRepository.GetFuelByIdAsync(fuelDto.Id);
        if (fuel != null)
        {
            fuel.Name = fuelDto.Name;
            await _fuelRepository.UpdateAsync(fuel);
        }
    }

    //public async Task DeleteFuelAsync(int id)
    //{
    //    await _fuelRepository.DeleteAsync(id);
    //}
    public async Task DeleteFuelAsync(int id)
    {
        var fuel = await _fuelRepository.GetFuelByIdAsync(id);
        if (fuel != null)
        {
            _fuelRepository.DeleteAsync(fuel.Id);  // fuel.Id kullanarak silme işlemi yapıyoruz.
        }
    }
}

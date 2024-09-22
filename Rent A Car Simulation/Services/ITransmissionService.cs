using Rent_A_Car_Simulation.Models;
 
using System.Collections.Generic;
using System.Threading.Tasks;
using Rent_A_Car_Simulation.DTOs;

namespace Rent_A_Car_Simulation.Services.Interfaces
{
    public interface ITransmissionService
    {
        Task<List<TransmissionDto>> GetAllTransmissionsAsync();
        Task<TransmissionDto?> GetTransmissionByIdAsync(int id);
        Task AddTransmissionAsync(TransmissionDto transmissionDto);
        Task UpdateTransmissionAsync(TransmissionDto transmissionDto);
        Task DeleteTransmissionAsync(int id);
    }
}


using Entities.DataTransferObject;

namespace Services.Abstract
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
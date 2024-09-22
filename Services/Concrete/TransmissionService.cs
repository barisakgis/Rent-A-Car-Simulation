
using Entities.DataTransferObject;
using Entities.Models;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class TransmissionService : ITransmissionService
    {
        private readonly ITransmissionRepository _transmissionRepository;

        public TransmissionService(ITransmissionRepository transmissionRepository)
        {
            _transmissionRepository = transmissionRepository;
        }

        public async Task<List<TransmissionDto>> GetAllTransmissionsAsync()
        {
            var transmissions = await _transmissionRepository.GetAllTransmissionsAsync();
            return transmissions.ConvertAll(t => new TransmissionDto { Id = t.Id, Name = t.Name });
        }

        public async Task<TransmissionDto?> GetTransmissionByIdAsync(int id)
        {
            var transmission = await _transmissionRepository.GetTransmissionByIdAsync(id);
            if (transmission == null)
                return null;
            return new TransmissionDto { Id = transmission.Id, Name = transmission.Name };
        }

        public async Task AddTransmissionAsync(TransmissionDto transmissionDto)
        {
            var transmission = new Transmission
            {
                Name = transmissionDto.Name
            };
            await _transmissionRepository.AddAsync(transmission);
        }

        public async Task UpdateTransmissionAsync(TransmissionDto transmissionDto)
        {
            var transmission = await _transmissionRepository.GetTransmissionByIdAsync(transmissionDto.Id);
            if (transmission != null)
            {
                transmission.Name = transmissionDto.Name;
                _transmissionRepository.UpdateAsync(transmission);
            }
        }

        public async Task DeleteTransmissionAsync(int id)
        {
            var transmission = await _transmissionRepository.GetTransmissionByIdAsync(id);
            if (transmission != null)
            {
                _transmissionRepository.DeleteAsync(transmission.Id);
            }
        }
    }
}



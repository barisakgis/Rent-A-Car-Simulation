using Entities.Models;

namespace Repositories.Abstract
{
    public interface IColorRepository : IGenericRepository<Color>
    {
        Task<List<Color>> GetAllColorsAsync();
        Task<Color> GetColorByIdAsync(int id);
        Task<List<Color>> GetColorsByNameContainsAsync(string name);


        // Eklenen metotlar
        Task AddAsync(Color color);
        Task UpdateAsync(Color color);
        Task DeleteAsync(int id);
    }
}

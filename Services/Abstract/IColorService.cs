
using Entities.DataTransferObject;

namespace Services.Abstract
{
    public interface IColorService
    {
        Task<List<ColorDto>> GetAllColorsAsync();
        Task<ColorDto?> GetColorByIdAsync(int id);
        Task AddColorAsync(ColorDto colorDto);
        Task UpdateColorAsync(ColorDto colorDto);
        Task DeleteColorAsync(int id);
    }
}

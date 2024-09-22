using Microsoft.EntityFrameworkCore;
using Entities.DataTransferObject;
using Entities.Models;
using Repositories.Abstract;
using Repositories.Context;
namespace Repositories.Concrete
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(RentACarDbContext context) : base(context) { }

        public async Task<List<Color>> GetAllColorsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Color> GetColorByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<List<Color>> GetColorsByNameContainsAsync(string name)
        {
            return await _dbSet.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task AddAsync(Color color)
        {
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Color color)
        {
            _context.Colors.Update(color);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var color = await GetColorByIdAsync(id);
            if (color != null)
            {
                _context.Colors.Remove(color);
                await _context.SaveChangesAsync();
            }
        }

    }
}

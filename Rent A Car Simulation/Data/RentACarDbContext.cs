using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Simulation.Models;

namespace Rent_A_Car_Simulation.Data
{
    

    public class RentACarDbContext : DbContext
    {
        public RentACarDbContext(DbContextOptions<RentACarDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
    }

}

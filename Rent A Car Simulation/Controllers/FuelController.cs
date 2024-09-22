using Microsoft.AspNetCore.Mvc;
using Entities.DataTransferObject;
using Services.Abstract;
using System.Threading.Tasks;

namespace Rent_A_Car_Simulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        private readonly IFuelService _fuelService;

        public FuelController(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFuels()
        {
            var fuels = await _fuelService.GetAllFuelsAsync();
            return Ok(fuels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuelById(int id)
        {
            var fuel = await _fuelService.GetFuelByIdAsync(id);
            if (fuel == null)
                return NotFound();
            return Ok(fuel);
        }

        [HttpPost]
        public async Task<IActionResult> AddFuel([FromBody] FuelDto fuelDto)
        {
            await _fuelService.AddFuelAsync(fuelDto);
            return CreatedAtAction(nameof(GetFuelById), new { id = fuelDto.Id }, fuelDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFuel(int id, [FromBody] FuelDto fuelDto)
        {
            if (id != fuelDto.Id)
                return BadRequest();

            await _fuelService.UpdateFuelAsync(fuelDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuel(int id)
        {
            await _fuelService.DeleteFuelAsync(id);
            return NoContent();
        }
    }
}

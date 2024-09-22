using Entities.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;


namespace Rent_A_Car_Simulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetCarDetails()
        {
            var result = await _carService.GetAllDetailsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDetailById(int id)
        {
            var result = await _carService.GetDetailByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("fuel/{fuelId}")]
        public async Task<IActionResult> GetCarsByFuelId(int fuelId)
        {
            var result = await _carService.GetAllDetailsByFuelIdAsync(fuelId);
            return Ok(result);
        }

        [HttpGet("color/{colorId}")]
        public async Task<IActionResult> GetCarsByColorId(int colorId)
        {
            var result = await _carService.GetAllDetailsByColorIdAsync(colorId);
            return Ok(result);
        }

        [HttpGet("price-range")]
        public async Task<IActionResult> GetCarsByPriceRange(double min, double max)
        {
            var result = await _carService.GetAllDetailsByPriceRangeAsync(min, max);
            return Ok(result);
        }

        [HttpGet("brand")]
        public async Task<IActionResult> GetCarsByBrandName(string brandName)
        {
            var result = await _carService.GetAllDetailsByBrandNameContainsAsync(brandName);
            return Ok(result);
        }

        [HttpGet("model")]
        public async Task<IActionResult> GetCarsByModelName(string modelName)
        {
            var result = await _carService.GetAllDetailsByModelNameContainsAsync(modelName);
            return Ok(result);
        }

        [HttpGet("kilometer-range")]
        public async Task<IActionResult> GetCarsByKilometerRange(int min, int max)
        {
            var result = await _carService.GetAllDetailsByKilometerRangeAsync(min, max);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CarDto carDto)
        {
            try
            {
                await _carService.AddCarAsync(carDto);
                return CreatedAtAction(nameof(GetCarDetailById), new { id = carDto.Id }, carDto);
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
          
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] CarDto carDto)
        {
            await _carService.UpdateCarAsync(carDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteCarAsync(id);
            return NoContent();
        }
    }
}


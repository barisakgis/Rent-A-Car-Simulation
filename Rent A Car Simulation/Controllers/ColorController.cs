using Entities.DataTransferObject;
using Services.Abstract;
using Microsoft.AspNetCore.Mvc;



namespace Rent_A_Car_Simulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllColors()
        {
            var colors = await _colorService.GetAllColorsAsync();
            return Ok(colors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColorById(int id)
        {
            var color = await _colorService.GetColorByIdAsync(id);
            if (color == null)
            {
                return NotFound();
            }
            return Ok(color);
        }

        [HttpPost]
        public async Task<IActionResult> AddColor([FromBody] ColorDto colorDto)
        {
            await _colorService.AddColorAsync(colorDto);
            return CreatedAtAction(nameof(GetColorById), new { id = colorDto.Id }, colorDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateColor([FromBody] ColorDto colorDto)
        {
            await _colorService.UpdateColorAsync(colorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            await _colorService.DeleteColorAsync(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc; 
using Rent_A_Car_Simulation.DTOs;
using Rent_A_Car_Simulation.Services.Interfaces;
using System.Threading.Tasks;

namespace Rent_A_Car_Simulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionController : ControllerBase
    {
        private readonly ITransmissionService _transmissionService;

        public TransmissionController(ITransmissionService transmissionService)
        {
            _transmissionService = transmissionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransmissions()
        {
            var result = await _transmissionService.GetAllTransmissionsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransmissionById(int id)
        {
            var result = await _transmissionService.GetTransmissionByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransmission([FromBody] TransmissionDto transmissionDto)
        {
            await _transmissionService.AddTransmissionAsync(transmissionDto);
            return CreatedAtAction(nameof(GetTransmissionById), new { id = transmissionDto.Id }, transmissionDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransmission([FromBody] TransmissionDto transmissionDto)
        {
            await _transmissionService.UpdateTransmissionAsync(transmissionDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransmission(int id)
        {
            await _transmissionService.DeleteTransmissionAsync(id);
            return NoContent();
        }
    }
}

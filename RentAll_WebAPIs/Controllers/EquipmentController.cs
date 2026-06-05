using Microsoft.AspNetCore.Mvc;
using RentAll_WebAPIs.Models;
using RentAll_WebAPIs.Services;

namespace RentAll_WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Equipment>>> GetAll()
        {
            return await _equipmentService.GetAllEquipmentAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetById(int id)
        {
            var equipment = await _equipmentService.GetEquipmentByIdAsync(id);

            if (equipment == null)
                return NotFound();

            return equipment;
        }

        [HttpPost]
        public async Task<ActionResult<Equipment>> Create(Equipment equipment)
        {
            var created = await _equipmentService.AddEquipmentAsync(equipment);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Equipment equipment)
        {
            var updated = await _equipmentService.UpdateEquipmentAsync(id, equipment);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _equipmentService.DeleteEquipmentAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
using IndustryMachineManagementSystem.Client.Dtos;
using IndustryMachineManagementSystem.Client.Services;
using IndustryMachineManagementSystem.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace IndustryMachineManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachinesController : ControllerBase
    {
        private readonly IMachineService _machineService;

        public MachinesController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        // GET: api/machines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineDto>>> GetMachines()
        {
            var machines = await _machineService.GetMachinesAsync();

            return Ok(machines);
        }

        // GET: api/machines/1
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MachineDto>> GetMachine(Guid id)
        {
            var machine = await _machineService.GetMachineAsync(id);

            if (machine == null)
                return NotFound();

            return Ok(machine);
        }

        // POST: api/machines
        [HttpPost]
        public async Task<ActionResult<MachineDto>> CreateMachine(
            CreateMachineDto machine)
        {
            var createdMachine =
                await _machineService.CreateMachineAsync(machine);

            return CreatedAtAction(
                nameof(GetMachine),
                new { id = createdMachine.Id },
                createdMachine);
        }

        // PUT: api/machines/1
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateMachine(
            Guid id,
            UpdateMachineDto machine)
        {
            var updated =
                await _machineService.UpdateMachineAsync(id, machine);

            if (updated == null)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/machines/1
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMachine(Guid id)
        {
             await _machineService.DeleteMachineAsync(id);

            return NoContent();
        }
    }
}

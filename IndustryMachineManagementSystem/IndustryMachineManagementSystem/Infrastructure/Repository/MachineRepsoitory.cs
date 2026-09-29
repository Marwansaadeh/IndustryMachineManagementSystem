using IndustryMachineManagementSystem.Contracts;
using IndustryMachineManagementSystem.Domain.Models;
using IndustryMachineManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndustryMachineManagementSystem.Infrastructure.Repository
{
    public class MachineRepsoitory : RepositoryBase<Machine>, IMachineRepsoitory
    {
        private readonly ApplicationDbContext _context;

        public MachineRepsoitory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Machine?> GetMachineAsync(Guid id, bool trackChanges = false)
        {
            return await GetMachineQuary(id, trackChanges);
        }
        public async Task<List<Machine>> GetMachinesAsync(bool trackChanges = false)
        {
            return await GetAllMachinesByQuary(trackChanges);
        }
        public async Task<Machine> GetMachineQuary(Guid id, bool trackChanges = false)
        {
            var machine = await _context.Machines.FirstAsync(m => m.Id == id);
            if (machine == null)
            {
                throw new KeyNotFoundException($"Machine with ID {id} not found.");
            }
            return machine;
        }
        private async Task<List<Machine>> GetAllMachinesByQuary(bool trackChanges = false)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
    }
}

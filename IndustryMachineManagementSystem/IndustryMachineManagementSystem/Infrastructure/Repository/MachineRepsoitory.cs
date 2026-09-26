using IndustryMachineManagementSystem.Contracts;
using IndustryMachineManagementSystem.Domain.Models;
using IndustryMachineManagementSystem.Infrastructure.Data;

namespace IndustryMachineManagementSystem.Infrastructure.Repository
{
    public class MachineRepsoitory : RepositoryBase<Machine>, IMachineRepsoitory
    {
        private readonly ApplicationDbContext _context;

        public MachineRepsoitory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Machine?> GetMachineAsync(Guid id, bool trackChanges = false)
        {
            return GetMachineAsync(id, trackChanges);
        }
        public Task<IEnumerable<Machine>> GetMachinesAsync(bool trackChanges = false)
        {
            return GetMachinesAsync(trackChanges);
        }




        //public async Task<IEnumerable<Guid>> GetValidPositionIds(List<Guid> positionIds)
        //{
        //    return await _context.Positions
        //                                 .Where(p => positionIds.Contains(p.Id))
        //                                 .Select(p => p.Id)
        //                                 .ToListAsync();
        //}
    }
}

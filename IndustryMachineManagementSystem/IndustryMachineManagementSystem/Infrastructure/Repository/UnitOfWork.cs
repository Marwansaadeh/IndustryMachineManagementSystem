using IndustryMachineManagementSystem.Contracts;
using IndustryMachineManagementSystem.Infrastructure.Data;

namespace IndustryMachineManagementSystem.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Lazy<IMachineRepsoitory> _movieRepsoitory;
        public IMachineRepsoitory MachineRepsoitory => _movieRepsoitory.Value;

        public UnitOfWork(ApplicationDbContext context, Lazy<IMachineRepsoitory> machineRepsoitory)
        {
            _context = context;
            _movieRepsoitory = machineRepsoitory;
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
    }
}

using IndustryMachineManagementSystem.Domain.Models;

namespace IndustryMachineManagementSystem.Contracts
{
    public interface IMachineRepsoitory : IRepositoryBase<Machine>
    {
        Task<List<Machine>> GetMachinesAsync(bool trackChanges = false);
        Task<Machine?> GetMachineAsync(Guid id, bool trackChanges = false);
    }
}

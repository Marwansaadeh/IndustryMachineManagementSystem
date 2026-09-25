using IndustryMachineManagementSystem.Client.Models;    
namespace IndustryMachineManagementSystem.Client.Services
{
    public interface IMachineService
    {
        Task<List<Machine>> GetMachinesAsync();
        Task<Machine> GetMachineByIdAsync(Guid id);
        Task<Machine> CreateMachineAsync(Machine machine);
        Task UpdateMachineAsync(Machine machine);
        Task DeleteMachineAsync(Guid id);
        Task StartMachineAsync(Guid id);
        Task StopMachineAsync(Guid id);

    }
}

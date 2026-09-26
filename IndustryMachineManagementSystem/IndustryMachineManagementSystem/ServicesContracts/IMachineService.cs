using IndustryMachineManagementSystem.Client.Dtos;

namespace IndustryMachineManagementSystem.ServicesContracts
{
    public interface IMachineService
    {
        Task<IEnumerable<MachineDto>> GetMachinesAsync(bool trackChanges = false);
        Task<MachineDto> GetMachineAsync(Guid id, bool trackChanges = false);
        Task<MachineDto> UpdateMachineAsync(Guid id, UpdateMachineDto dto);
        Task<MachineDto> CreateMachineAsync(CreateMachineDto dto);
        Task DeleteMachineAsync(Guid id);
    }
}

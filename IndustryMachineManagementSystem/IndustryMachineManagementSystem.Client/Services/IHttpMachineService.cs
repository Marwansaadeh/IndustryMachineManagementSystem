using IndustryMachineManagementSystem.Client.Dtos;
namespace IndustryMachineManagementSystem.Client.Services
{
    public interface IHttpMachineService
    {
        Task<List<MachineDto>> GetMachinesAsync();
        Task<MachineDto> GetMachineByIdAsync(Guid id);
        Task<MachineDto> CreateMachineAsync(CreateMachineDto machine);
        Task<MachineDto> UpdateMachineAsync(UpdateMachineDto machine, Guid id);
        Task<bool> DeleteMachineAsync(Guid id);
        Task<MachineDto> StartMachineAsync(Guid id);
        Task<MachineDto> StopMachineAsync(Guid id);

    }
}

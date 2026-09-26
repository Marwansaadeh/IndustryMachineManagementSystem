using IndustryMachineManagementSystem.Client.Dtos;
namespace IndustryMachineManagementSystem.Client.Services
{
    public interface IHttpMachineService
    {
        Task<List<MachineDto>> GetMachinesAsync();
        Task<MachineDto> GetMachineByIdAsync(Guid id);
        Task<MachineDto> CreateMachineAsync(CreateMachineDto machine);
        Task UpdateMachineAsync(UpdateMachineDto machine);
        Task DeleteMachineAsync(Guid id);
        Task StartMachineAsync(Guid id);
        Task StopMachineAsync(Guid id);

    }
}

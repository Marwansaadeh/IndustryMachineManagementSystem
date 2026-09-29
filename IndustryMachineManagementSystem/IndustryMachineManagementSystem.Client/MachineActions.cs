using IndustryMachineManagementSystem.Client.Dtos;
using Microsoft.AspNetCore.Components;

namespace IndustryMachineManagementSystem.Client
{
    public class MachineActions
    {
        public EventCallback<CreateMachineDto> CreateMachineAsync { get; init; }
        public EventCallback<Guid> DeleteMachineAsync { get; init; }
        public EventCallback<Guid> StartMachineAsync { get; init; }
        public EventCallback<Guid> StopMachineAsync { get; init; }
        public EventCallback<UpdateMachineRequest> UpdateMachineAsync { get; init; }
    }
}

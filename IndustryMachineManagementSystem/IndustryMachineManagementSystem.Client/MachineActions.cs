using IndustryMachineManagementSystem.Client.Models;
using Microsoft.AspNetCore.Components;

namespace IndustryMachineManagementSystem.Client
{
    public class MachineActions
    {
        public EventCallback<Machine> CreateMachineAsync { get; init; }
        public EventCallback<Guid> DeleteMachineAsync { get; init; }
        public EventCallback<Guid> StartMachineAsync { get; init; }
        public EventCallback<Guid> StopMachineAsync { get; init; }
        public EventCallback<Machine> UpdateMachineAsync { get; init; }
    }
}

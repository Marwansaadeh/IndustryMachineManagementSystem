using IndustryMachineManagementSystem.Client.Dtos;

namespace IndustryMachineManagementSystem.Client.Services
{
    public class HttpMachineService : IHttpMachineService
    {
        private readonly List<MachineDto> _machines;
        public HttpMachineService()
        {
            _machines = GetInitialMachines();
        }
        public Task<MachineDto> CreateMachineAsync(CreateMachineDto machine)
        {
            MachineDto machineDto = new MachineDto();

            if (machine == null)
            {
                machineDto?.LastData = "No data";
                machineDto?.IsOnline = false;
                machineDto?.Name = string.IsNullOrWhiteSpace(machine.Name) ? $"Machine {_machines.Count + 1}" : machine.Name;
            }
            _machines.Add(machineDto!);
            return Task.FromResult(machineDto!);
        }

        public Task DeleteMachineAsync(Guid id)
        {
            if (_machines.Any(m => m.Id == id))
            {
                _machines.RemoveAll(m => m.Id == id);
            }
            return Task.CompletedTask;
        }

        public Task<MachineDto> GetMachineByIdAsync(Guid id)
        {
            var machine = _machines.FirstOrDefault(m => m.Id == id);
            return Task.FromResult(machine)!;
        }

        public Task<List<MachineDto>> GetMachinesAsync()
        {
            return Task.FromResult(_machines);
        }

        public Task StartMachineAsync(Guid id)
        {
            if (_machines.Any(m => m.Id == id))
            {
                var machine = _machines.First(m => m.Id == id);
                machine.IsOnline = true;
                machine.LastUpdated = DateTime.Now;
            }
            return Task.CompletedTask;
        }

        public Task StopMachineAsync(Guid id)
        {
            if (_machines.Any(m => m.Id == id))
            {
                var machine = _machines.First(m => m.Id == id);
                machine.IsOnline = false;
                machine.LastUpdated = DateTime.Now;
            }
            return Task.CompletedTask;
        }

        public Task UpdateMachineAsync(UpdateMachineDto machine)
        {
            var existingMachine = _machines.FirstOrDefault(m => m.Id == machine.Id);
            if (existingMachine != null)
            {
                existingMachine.Name = machine.Name;
                existingMachine.IsOnline = machine.IsOnline;
                existingMachine.LastData = machine.LastData;
                existingMachine.LastUpdated = DateTime.Now;
            }
            return Task.CompletedTask;
        }

        private List<MachineDto> GetInitialMachines()
        {
            return new List<MachineDto>
            {

    new MachineDto
    {
        Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        Name = "Machine 1",
        IsOnline = true,
        LastData = "Temperature: 23.4°C",
        LastUpdated = DateTime.Now.AddMinutes(-2)
    },
    new MachineDto
    {
        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        Name = "Machine 2",
        IsOnline = true,
        LastData = "Temperature: 21.8°C",
        LastUpdated = DateTime.Now.AddMinutes(-5)
    },
    new MachineDto
    {
        Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
        Name = "Machine 3",
        IsOnline = false,
        LastData = "No data",
        LastUpdated = DateTime.Now.AddHours(-2)
    },
    new MachineDto
    {
        Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
        Name = "Machine 4",
        IsOnline = true,
        LastData = "Temperature: 25.1°C",
        LastUpdated = DateTime.Now.AddMinutes(-1)
    },

            };
        }
    }
}
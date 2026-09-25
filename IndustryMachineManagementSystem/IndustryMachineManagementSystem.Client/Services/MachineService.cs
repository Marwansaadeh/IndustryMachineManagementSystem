using IndustryMachineManagementSystem.Client.Models;

namespace IndustryMachineManagementSystem.Client.Services
{
    public class MachineService : IMachineService
    {
        private readonly List<Machine> _machines;
        public MachineService()
        {
            _machines = GetInitialMachines();
        }
        public Task<Machine> CreateMachineAsync(Machine machine)
        {
            if(machine == null)
            {
                machine = new Machine();
                machine?.Id = Guid.NewGuid();
                machine?.LastData = "No data";
                machine?.IsOnline = false;
                machine?.Name = string.IsNullOrWhiteSpace(machine.Name) ? $"Machine {_machines.Count + 1}" : machine.Name;
            }
            _machines.Add(machine!);
            return Task.FromResult(machine!);
        }

        public Task DeleteMachineAsync(Guid id)
        {
            if (_machines.Any(m => m.Id == id))
            {
                _machines.RemoveAll(m => m.Id == id);
            }
            return Task.CompletedTask;
        }

        public Task<Machine> GetMachineByIdAsync(Guid id)
        {
            var machine = _machines.FirstOrDefault(m => m.Id == id);
            return Task.FromResult(machine)!;
        }

        public Task<List<Machine>> GetMachinesAsync()
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

        public Task UpdateMachineAsync(Machine machine)
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

        private List<Machine> GetInitialMachines()
        {
            return new List<Machine>
            {

    new Machine
    {
        Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        Name = "Machine 1",
        IsOnline = true,
        LastData = "Temperature: 23.4°C",
        LastUpdated = DateTime.Now.AddMinutes(-2)
    },
    new Machine
    {
        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        Name = "Machine 2",
        IsOnline = true,
        LastData = "Temperature: 21.8°C",
        LastUpdated = DateTime.Now.AddMinutes(-5)
    },
    new Machine
    {
        Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
        Name = "Machine 3",
        IsOnline = false,
        LastData = "No data",
        LastUpdated = DateTime.Now.AddHours(-2)
    },
    new Machine
    {
        Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
        Name = "Machine 4",
        IsOnline = true,
        LastData = "Temperature: 25.1°C",
        LastUpdated = DateTime.Now.AddMinutes(-1)
    },
    new Machine
    {
        Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
        Name = "Machine 5",
        IsOnline = false,
        LastData = "No data",
        LastUpdated = DateTime.Now.AddHours(-5)
    },
    new Machine
    {
        Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
        Name = "Machine 6",
        IsOnline = true,
        LastData = "Temperature: 22.6°C",
        LastUpdated = DateTime.Now.AddMinutes(-10)
    },
    new Machine
    {
        Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
        Name = "Machine 7",
        IsOnline = true,
        LastData = "Temperature: 24.3°C",
        LastUpdated = DateTime.Now.AddMinutes(-3)
    },
    new Machine
    {
        Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
        Name = "Machine 8",
        IsOnline = false,
        LastData = "No data",
        LastUpdated = DateTime.Now.AddHours(-1)
    },
    new Machine
    {
        Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
        Name = "Machine 9",
        IsOnline = true,
        LastData = "Temperature: 20.9°C",
        LastUpdated = DateTime.Now.AddMinutes(-7)
    },
    new Machine
    {
        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
        Name = "Machine 10",
        IsOnline = true,
        LastData = "Temperature: 26.2°C",
        LastUpdated = DateTime.Now.AddMinutes(-4)
    }


            };
        }
    }
}

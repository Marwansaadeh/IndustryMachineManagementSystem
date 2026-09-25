namespace IndustryMachineManagementSystem.Client.Models
{
    public class Machine
    {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public bool IsOnline { get; set; }
            public string LastData { get; set; } = string.Empty;
            public DateTimeOffset LastUpdated { get; set; }
        }
    }

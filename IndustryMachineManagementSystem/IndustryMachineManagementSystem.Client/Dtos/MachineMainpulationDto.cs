namespace IndustryMachineManagementSystem.Client.Dtos
{
    public class MachineMainpulationDto
    {
        public string Name { get; set; } = string.Empty;
        public bool IsOnline { get; set; }
        public string LastData { get; set; } = string.Empty;
        public DateTimeOffset LastUpdated { get; set; }
    }
}

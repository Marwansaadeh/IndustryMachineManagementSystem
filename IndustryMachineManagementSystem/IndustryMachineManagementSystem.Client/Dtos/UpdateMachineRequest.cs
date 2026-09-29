namespace IndustryMachineManagementSystem.Client.Dtos
{
    public class UpdateMachineRequest
    {
        public Guid Id { get; set; }
        public UpdateMachineDto Machine { get; set; } = null!;
    }
}

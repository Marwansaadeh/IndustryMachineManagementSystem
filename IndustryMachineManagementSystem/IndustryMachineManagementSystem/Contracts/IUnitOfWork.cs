namespace IndustryMachineManagementSystem.Contracts
{
    public interface IUnitOfWork
    {
        IMachineRepsoitory MachineRepsoitory { get; }
        Task<int> CompleteAsync();
    }
}

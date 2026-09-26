namespace IndustryMachineManagementSystem.Domain.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        public string Title { get; }
        protected NotFoundException(string message, string title = "Not Found") : base(message)
        {
            Title = title;
        }
    }

    public sealed class MachineNotFoundException(Guid id) : NotFoundException($"The machine with id: {id} was not found")
    {
    }

}

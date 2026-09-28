using IndustryMachineManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using Machine = IndustryMachineManagementSystem.Domain.Models.Machine;

namespace IndustryMachineManagementSystem.Services
{
    public class DataSeedService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IConfiguration configuration;
        private readonly ILogger<DataSeedService> logger;
        public DataSeedService(IServiceProvider serviceProvider, IConfiguration configuration, ILogger<DataSeedService> logger)
        {
            this.serviceProvider = serviceProvider;
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();

            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
            if (!env.IsDevelopment()) return;

            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>()
                                ?? throw new ArgumentNullException();

            if (await context.Machines.AnyAsync(cancellationToken)) return;


            try
            {
               
                    var machines = new List<Machine>
                    {
                        new Machine {
                            Id = Guid.NewGuid(),
                            Name = "Machine 1",
                            IsOnline = true,
                            LastData = "Data 1",
                            LastUpdated = DateTimeOffset.UtcNow
                        },
                        new Machine {
                            Id = Guid.NewGuid(),
                            Name = "Machine 2",
                            IsOnline = false,
                            LastData = "Data 2",
                            LastUpdated = DateTimeOffset.UtcNow
                        },
                        new Machine {
                            Id = Guid.NewGuid(),
                            Name = "Machine 3",
                            IsOnline = true,
                            LastData = "Data 3",
                            LastUpdated = DateTimeOffset.UtcNow
                        }
                    };
                    await context.Machines.AddRangeAsync(machines, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                
            }
            catch (Exception ex)
            {
                logger.LogError($"Data seed fail with message: {ex.Message}. Exceeption: {ex.InnerException}");
                throw;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    }
}

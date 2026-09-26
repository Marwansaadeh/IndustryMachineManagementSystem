using IndustryMachineManagementSystem.Contracts;
using IndustryMachineManagementSystem.Infrastructure.Repository;
using IndustryMachineManagementSystem.Services;
using IndustryMachineManagementSystem.ServicesContracts;

namespace IndustryMachineManagementSystem.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMachineRepsoitory, MachineRepsoitory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(provider => new Lazy<IMachineRepsoitory>(() => provider.GetRequiredService<IMachineRepsoitory>()));
        }

        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IMachineService, MachineService>();
            services.AddLazy<IMachineService>();
        }
    }
}

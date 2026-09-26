using IndustryMachineManagementSystem.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace IndustryMachineManagementSystem.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped<IHttpMachineService, HttpMachineService>();

            await builder.Build().RunAsync();
        }
    }
}

using IndustryMachineManagementSystem.Client.Services;
using IndustryMachineManagementSystem.Components;
using IndustryMachineManagementSystem.Extensions;
using IndustryMachineManagementSystem.Infrastructure.Data;
using IndustryMachineManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace IndustryMachineManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddHostedService<DataSeedService>();
            builder.Services.AddServiceLayer();
            builder.Services.AddRepositories();
            builder.Services.AddAutoMapper(cfg => { }, typeof(MapperProfile));
           

            builder.Services.AddControllers();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
            app.MapControllers();
            app.Run();
        }
    }
}

using IndustryMachineManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IndustryMachineManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Machine> Machines
        {
            get; set;
        } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Machine>().ToTable("Machines");
        }
    }
}

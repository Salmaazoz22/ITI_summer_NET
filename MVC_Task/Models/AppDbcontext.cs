using Microsoft.EntityFrameworkCore;

namespace MVC_Task.Models
{
    public class AppDbcontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=MVCTaskG2;Trusted_Connection=True;TrustServerCertificate=True"
            );
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}


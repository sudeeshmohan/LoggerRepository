using Employee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Persistence
{
    public class EmployeeDbContext : DbContext
    {

        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Data Source=DESKTOP-5TP1N5F\\SQLEXPRESS;Initial Catalog=EmployeeDb; Integrated Security=true");
        }

        public DbSet<EmployeeDetail> Employee { get; set; }
        public DbSet<EmployeePayment> EmployeePayment { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
    }
}

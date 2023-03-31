using Employee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Persistence
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmployeeDetail> Employee { get; set; }
        public DbSet<EmployeePayment> EmployeePayment { get; set; }
    }
}

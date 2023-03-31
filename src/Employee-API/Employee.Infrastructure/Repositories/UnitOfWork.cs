using Employee.Application.Contracts;
using Employee.Infrastructure.Persistence;

namespace Employee.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private readonly EmployeeDbContext dbContext;

        private IEmployeeRepository _employee;
        public IEmployeeRepository Employee
        {
            get { return _employee ?? new EmployeeRepository(dbContext); }
            set { _employee = value; }
        }

        private IPaymentServices _payment;
        public IPaymentServices Payment
        {
            get { return _payment ?? new PaymentServices(dbContext); }
            set { _payment = value; }
        }
    }
}

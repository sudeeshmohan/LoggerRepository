using Employee.Domain.Entities;

namespace Employee.Application.Contracts
{
    public interface IEmployeeRepository : IRepository<EmployeeDetail>
    {

    }
}

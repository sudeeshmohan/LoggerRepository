using Employee.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Application.Contracts
{
    public interface IPaymentServices : IRepository<EmployeePayment>
    {
        Task<List<EmployeePayment>> GetAllByEmployeeId(long employeeId);
    }
}

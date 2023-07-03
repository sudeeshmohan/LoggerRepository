using Employee.Domain.Entities;

namespace UI.ApiIntegration.Abstract
{
    public interface IPaymentService
    {
        Task<List<EmployeePayment>> GetPaymentEmpById(long id);
    }
}

using Employee.Domain.Entities;

namespace UI.ApiIntegration.Abstract
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDetail>> GetAllEmployee();
        Task<EmployeeDetail> GetById(long id);
    }
}

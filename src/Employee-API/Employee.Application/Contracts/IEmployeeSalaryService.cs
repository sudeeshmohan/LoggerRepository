using Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Contracts
{
    public interface IEmployeeSalaryService: IRepository<EmployeeSalary>
    {
    }
}

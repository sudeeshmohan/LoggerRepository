using Employee.Application.Contracts;
using Employee.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeSalaryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await unitOfWork.Salary.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long Id)
        {
            var response = await unitOfWork.Salary.GetByIdAsync(Id);
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(EmployeeSalary detail)
        {
            var response = await unitOfWork.Salary.AddAsync(detail);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long Id)
        {
            var response = await unitOfWork.Salary.DeleteAsync(Id);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EmployeeSalary entity)
        {
            var response = await unitOfWork.Salary.UpdateAsync(entity);
            return Ok(response);
        }
    }
}

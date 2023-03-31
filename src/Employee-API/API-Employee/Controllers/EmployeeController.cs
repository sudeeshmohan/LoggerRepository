using Employee.Application.Contracts;
using Employee.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await unitOfWork.Employee.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long Id)
        {
            var response = await unitOfWork.Employee.GetByIdAsync(Id);
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(EmployeeDetail detail)
        {
            var response = await unitOfWork.Employee.AddAsync(detail);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long Id)
        {
            var response = await unitOfWork.Employee.DeleteAsync(Id);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EmployeeDetail entity)
        {
            var response = await unitOfWork.Employee.UpdateAsync(entity);
            return Ok(response);
        }
    }
}

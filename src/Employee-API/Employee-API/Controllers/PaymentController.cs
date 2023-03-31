using AutoMapper;
using Employee.Application.Contracts;
using Employee.Application.Model;
using Employee.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await unitOfWork.Payment.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long Id)
        {
            var response = await unitOfWork.Payment.GetByIdAsync(Id);
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(PaymentDto detail)
        {
            var input = mapper.Map<EmployeePayment>(detail);
            var response = await unitOfWork.Payment.AddAsync(input);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long Id)
        {
            var response = await unitOfWork.Payment.DeleteAsync(Id);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PaymentDto entity)
        {
            var input = mapper.Map<EmployeePayment>(entity);
            var response = await unitOfWork.Payment.UpdateAsync(input);
            return Ok(response);
        }
    }
}

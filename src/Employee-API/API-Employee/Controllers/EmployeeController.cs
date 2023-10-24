using Employee.Application.Contracts;
using Employee.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            IReadOnlyList<EmployeeDetail> response = null;
            try
            {
                response = await unitOfWork.Employee.GetAllAsync();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long Id)
        {
            EmployeeDetail response = null;
            try
            {
                response = await unitOfWork.Employee.GetByIdAsync(Id);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(EmployeeDetail detail)
        {
            bool response;
            try
            {
                response = await unitOfWork.Employee.AddAsync(detail);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long Id)
        {
            bool response;
            try
            {
                response = await unitOfWork.Employee.DeleteAsync(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EmployeeDetail entity)
        {
            bool response;
            try
            {
                response = await unitOfWork.Employee.UpdateAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
    }
}

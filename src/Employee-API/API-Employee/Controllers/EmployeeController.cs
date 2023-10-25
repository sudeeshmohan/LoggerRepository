using AutoMapper;
using Employee.Application.Contracts;
using Employee.Application.Model;
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
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IReadOnlyList<EmployeeDto> response = null;
            try
            {
                var emp = await unitOfWork.Employee.GetAllAsync();
                response = _mapper.Map<IReadOnlyList<EmployeeDetail>, List<EmployeeDto>>(emp);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long Id)
        {
            EmployeeDto response = null;
            try
            {
                var emp = await unitOfWork.Employee.GetByIdAsync(Id);
                response = _mapper.Map<EmployeeDetail, EmployeeDto>(emp);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(response);
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add(EmployeeDto detail)
        {
            bool response;
            try
            {
                var employee = _mapper.Map<EmployeeDto, EmployeeDetail>(detail);
                response = await unitOfWork.Employee.AddAsync(employee);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update(EmployeeDto entity)
        {
            bool response;
            try
            {
                var employee = _mapper.Map<EmployeeDto, EmployeeDetail>(entity);
                response = await unitOfWork.Employee.UpdateAsync(employee);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
    }
}

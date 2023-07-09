using Employee.Application.Contracts;
using Employee.Domain.Entities;
using Employee.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    internal class EmployeeSalaryService: IEmployeeSalaryService
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeeSalaryService(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddAsync(EmployeeSalary entity)
        {
            try
            {
                await dbContext.EmployeeSalary.AddAsync(entity);
                var res = dbContext.SaveChanges();
                return res > 0;
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                EmployeeSalary customer = new EmployeeSalary() { Id = id };
                dbContext.EmployeeSalary.Attach(customer);
                await Task.Run(() => dbContext.EmployeeSalary.Remove(customer));
                var res = dbContext.SaveChanges();
                return res > 0;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyList<EmployeeSalary>> GetAllAsync()
        {
            try
            {
                return await dbContext.EmployeeSalary.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public async Task<EmployeeSalary> GetByIdAsync(long id)
        {
            try
            {
                var rsponse = await dbContext.EmployeeSalary.FirstOrDefaultAsync(x => x.Id == id);
                return rsponse;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(EmployeeSalary entity)
        {
            try
            {
                await Task.Run(() => dbContext.EmployeeSalary.Update(entity));
                var response = dbContext.SaveChanges();
                return response > 0;
            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }
}

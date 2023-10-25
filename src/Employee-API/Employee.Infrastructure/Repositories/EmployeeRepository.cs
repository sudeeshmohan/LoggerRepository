using Employee.Application.Contracts;
using Employee.Domain.Entities;
using Employee.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddAsync(EmployeeDetail entity)
        {
            try
            {
                await dbContext.Employee.AddAsync(entity);
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
                EmployeeDetail customer = new EmployeeDetail() { Id = id };
                dbContext.Employee.Attach(customer);
                await Task.Run(() => dbContext.Employee.Remove(customer));
                var res = dbContext.SaveChanges();
                return res > 0;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyList<EmployeeDetail>> GetAllAsync()
        {
            try
            {
                //EmployeeDto
                return await dbContext.Employee.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public async Task<EmployeeDetail> GetByIdAsync(long id)
        {
            try
            {
                var rsponse = await dbContext.Employee.FirstOrDefaultAsync(x => x.Id == id);
                return rsponse;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(EmployeeDetail entity)
        {
            try
            {
                await Task.Run(() => dbContext.Employee.Update(entity));
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

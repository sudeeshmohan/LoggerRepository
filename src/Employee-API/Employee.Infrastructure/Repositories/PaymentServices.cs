using Employee.Application.Contracts;
using Employee.Domain.Entities;
using Employee.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    public class PaymentServices : IPaymentServices
    {
        private readonly EmployeeDbContext context;

        public PaymentServices(EmployeeDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(EmployeePayment entity)
        {
            try
            {
                await context.EmployeePayment.AddAsync(entity);
                var response = context.SaveChanges();
                return response > 0;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<EmployeePayment>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<EmployeePayment>> GetAllByEmployeeId(long employeeId)
        {
            var response = await Task.Run(() => context.EmployeePayment.Where(x => x.EmployeeDetailId == employeeId).ToList());
            return response;
        }

        public async Task<EmployeePayment> GetByIdAsync(long id)
        {
            var response = await context.EmployeePayment.FirstOrDefaultAsync(x => x.Id == id);
            return response;
        }

        public async Task<bool> UpdateAsync(EmployeePayment entity)
        {
            await Task.Run(() => context.EmployeePayment.Update(entity));
            var response = context.SaveChanges();
            return response > 0;
        }
    }
}

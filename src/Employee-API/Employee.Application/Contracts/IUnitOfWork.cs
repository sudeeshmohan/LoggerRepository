namespace Employee.Application.Contracts
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository Employee { get; set; }
        public IPaymentServices Payment { get; set; }
        public IEmployeeSalaryService Salary { get; set; }
    }
}

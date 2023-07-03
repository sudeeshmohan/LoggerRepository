using System;

namespace Employee.Domain.Entities
{
    public class EmployeeSalary
    {
        public long Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Hours { get; set; }
        public double SalaryPerHour { get; set; } = 0;
        public long EmployeeDetailId { get; set; }
        private double _salary;

        public double Salary
        {
            get { return _salary = Hours * SalaryPerHour; }
            set { _salary = value; }
        }

        public EmployeeDetail EmployeeDetail { get; set; }
    }
}

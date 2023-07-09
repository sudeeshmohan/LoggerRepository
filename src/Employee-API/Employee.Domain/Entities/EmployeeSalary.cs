using System;

namespace Employee.Domain.Entities
{
    public class EmployeeSalary
    {
        public long Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Hours { get; set; }
        public float SalaryPerHour { get; set; } = 0;
        public long EmployeeDetailId { get; set; }
        private float _salary;

        public float Salary
        {
            get { return _salary = Hours * SalaryPerHour; }
            set { _salary = value; }
        }

        public EmployeeDetail EmployeeDetail { get; set; }
    }
}

using System.Collections.Generic;

namespace Employee.Domain.Entities
{
    public class EmployeeDetail
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public List<EmployeePayment> EmployeePayment { get; set; }
        public List<EmployeeSalary> EmployeeSalary { get; set; }
    }
}

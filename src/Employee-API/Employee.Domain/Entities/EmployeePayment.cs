using System;

namespace Employee.Domain.Entities
{
    public class EmployeePayment
    {
        public long Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public double AmountPayed { get; set; } = 0;
        public long EmployeeDetailId { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }
    }
}

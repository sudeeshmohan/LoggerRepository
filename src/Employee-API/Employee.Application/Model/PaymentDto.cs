using System;

namespace Employee.Application.Model
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public double AmountPayed { get; set; } = 0;
        public long EmployeeDetailId { get; set; }
    }
}

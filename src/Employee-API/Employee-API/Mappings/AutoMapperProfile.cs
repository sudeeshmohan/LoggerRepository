using AutoMapper;
using Employee.Application.Model;
using Employee.Domain.Entities;

namespace Employee_API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        protected AutoMapperProfile()
        {
            CreateMap<EmployeePayment, PaymentDto>().ReverseMap();
        }
    }
}

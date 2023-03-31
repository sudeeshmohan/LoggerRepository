using API_Employee.Model;
using AutoMapper;
using Employee.Application.Model;
using Employee.Domain.Entities;

namespace API_Employee.Extensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<EmployeePayment, PaymentDto>().ReverseMap();
        }
    }
}

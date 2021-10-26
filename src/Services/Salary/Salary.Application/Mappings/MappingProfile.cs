using AutoMapper;
using Salary.Application.Features.Salary.Commands.AddEmployee;
using Salary.Application.Features.Salary.Commands.UpdateEmployee;
using Salary.Application.Features.Salary.Queries.GetSalaryByEmployeeCode;
using Salary.Domain.Entities;

namespace Salary.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Salaryy, SalaryDTO>().ReverseMap();
            CreateMap<Salaryy, AddEmployeeSalaryCommand>().ReverseMap();
            CreateMap<Salaryy, UpdateEmployeeSalaryCommand>().ReverseMap();
        }
    }
}

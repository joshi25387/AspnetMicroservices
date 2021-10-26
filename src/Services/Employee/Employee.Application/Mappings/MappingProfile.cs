using AutoMapper;
using Employee.Application.Features.Employees.Commands.AddEmployee;
using Employee.Application.Features.Employees.Commands.UpdateEmployee;
using Employee.Application.Features.Employees.Queries.GetEmployeesByDepartment;
using Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employeee, EmployeeDTO>().ReverseMap();
            CreateMap<Employeee, AddEmployeeCommand>().ReverseMap();
            CreateMap<Employeee, UpdateEmployeeCommand>().ReverseMap();
        }
    }
}

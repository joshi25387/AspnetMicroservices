using AutoMapper;
using Employee.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Queries.GetEmployeesByDepartment
{
    public class GetEmployeesByDepartmentQueryHandler : IRequestHandler<GetEmployeesByDepartmentQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeesByDepartmentQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> Handle(GetEmployeesByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var employeeList = await _employeeRepository.GetEmployeeByDepartment(request.DepartmentName);
            return _mapper.Map<List<EmployeeDTO>>(employeeList);
        }
    }
}

using AutoMapper;
using Salary.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Salary.Application.Features.Salary.Queries.GetSalaryByEmployeeCode;

namespace Salary.Application.Features.Salary.Queries.GetEmployeesByDepartment
{
    public class GetSalaryByEmployeeCodeQueryHandler : IRequestHandler<GetSalaryByEmployeeCodeQuery, SalaryDTO>
    {
        private readonly ISalaryRepository _salaryRepository;
        private readonly IMapper _mapper;

        public GetSalaryByEmployeeCodeQueryHandler(ISalaryRepository salaryRepository, IMapper mapper)
        {
            _salaryRepository = salaryRepository;
            _mapper = mapper;
        }

        public async Task<SalaryDTO> Handle(GetSalaryByEmployeeCodeQuery request, CancellationToken cancellationToken)
        {
            var employeeSalary = await _salaryRepository.GetSalaryByEmployeeCode(request.EmployeeCode);
            return _mapper.Map<SalaryDTO>(employeeSalary);
        }
    }
}

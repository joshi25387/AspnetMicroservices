using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Salary.Application.Contracts.Persistence;
using Salary.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Salary.Application.Features.Salary.Commands.AddEmployee
{
    public class AddEmployeeSalaryCommandHandler : IRequestHandler<AddEmployeeSalaryCommand, int>
    {
        private readonly ISalaryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddEmployeeSalaryCommandHandler> _logger;

        public AddEmployeeSalaryCommandHandler(ISalaryRepository repository, IMapper mapper, ILogger<AddEmployeeSalaryCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddEmployeeSalaryCommand request, CancellationToken cancellationToken)
        {
            var employeeSalaryEntity = _mapper.Map<Salaryy>(request);
            var newEmployeeSalary = await _repository.AddAsync(employeeSalaryEntity);

            _logger.LogInformation($"Salary of employee {newEmployeeSalary.EmployeeCode} is successfully added");

            return newEmployeeSalary.Id;
        }
    }
}

using AutoMapper;
using Employee.Application.Contracts.Persistence;
using Employee.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddEmployeeCommandHandler> _logger;

        public AddEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper, ILogger<AddEmployeeCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<Employeee>(request);
            var newEmployee = await _repository.AddAsync(employeeEntity);

            _logger.LogInformation($"Employee {newEmployee.EmployeeCode} is successfully created");

            return newEmployee.Id;
        }
    }
}

using AutoMapper;
using Employee.Application.Contracts.Persistence;
using Employee.Application.Exceptions;
using Employee.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateEmployeeCommandHandler> _logger;

        public UpdateEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper, ILogger<UpdateEmployeeCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var _employeeToUpdate = await _repository.GetByIdAsync(request.Id);
            if (_employeeToUpdate == null)
            {
                throw new NotFoundException(nameof(Employeee), request.Id);
            }

            _mapper.Map(request, _employeeToUpdate, typeof(UpdateEmployeeCommand), typeof(Employeee));
            await _repository.UpdateAsync(_employeeToUpdate);

            _logger.LogInformation($"Employee {_employeeToUpdate.EmployeeCode} is successfully updated");

            return Unit.Value;
            
        }
    }
}

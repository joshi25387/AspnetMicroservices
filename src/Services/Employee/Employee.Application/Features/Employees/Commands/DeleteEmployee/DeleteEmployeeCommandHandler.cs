using AutoMapper;
using Employee.Application.Contracts.Persistence;
using Employee.Application.Exceptions;
using Employee.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteEmployeeCommandHandler> _logger;

        public DeleteEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper, ILogger<DeleteEmployeeCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var _employeeToDelete = await _repository.GetByIdAsync(request.Id);

            if (_employeeToDelete == null)
            {
                throw new NotFoundException(nameof(Employeee), request.Id);
            }

            await _repository.DeleteAsync(_employeeToDelete);

            _logger.LogInformation($"Employee {_employeeToDelete.EmployeeCode} successfully deleted");
            return Unit.Value;
        }
    }
}

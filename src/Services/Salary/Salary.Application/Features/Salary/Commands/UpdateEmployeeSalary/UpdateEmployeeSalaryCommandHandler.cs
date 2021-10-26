using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Salary.Application.Contracts.Persistence;
using Salary.Application.Exceptions;
using Salary.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Salary.Application.Features.Salary.Commands.UpdateEmployee
{
    public class UpdateEmployeeSalaryCommandHandler : IRequestHandler<UpdateEmployeeSalaryCommand, Unit>
    {
        private readonly ISalaryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateEmployeeSalaryCommandHandler> _logger;

        public UpdateEmployeeSalaryCommandHandler(ISalaryRepository repository, IMapper mapper, ILogger<UpdateEmployeeSalaryCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateEmployeeSalaryCommand request, CancellationToken cancellationToken)
        {
            var _employeeSalaryToUpdate = await _repository.GetByIdAsync(request.Id);
            if (_employeeSalaryToUpdate == null)
            {
                throw new NotFoundException(nameof(Salaryy), request.Id);
            }

            _mapper.Map(request, _employeeSalaryToUpdate, typeof(UpdateEmployeeSalaryCommand), typeof(Salaryy));
            await _repository.UpdateAsync(_employeeSalaryToUpdate);

            _logger.LogInformation($"Salary of employee {_employeeSalaryToUpdate.EmployeeCode} is successfully updated");

            return Unit.Value;
            
        }
    }
}

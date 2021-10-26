using Employee.Application.Features.Employees.Commands.AddEmployee;
using Employee.Application.Features.Employees.Commands.DeleteEmployee;
using Employee.Application.Features.Employees.Commands.UpdateEmployee;
using Employee.Application.Features.Employees.Queries.GetEmployeesByDepartment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{departmentName}", Name = "GetEmployeesByDepartmentName")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeDTO>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByDepartmentName(string departmentName)
        {
            var query = new GetEmployeesByDepartmentQuery(departmentName);
            var employeeList = await _mediator.Send(query);
            return Ok(employeeList);
        }

        [HttpPost(Name = "AddEmployee")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddEmployee([FromBody] AddEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var command = new DeleteEmployeeCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

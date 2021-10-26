using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salary.Application.Features.Salary.Commands.AddEmployee;
using Salary.Application.Features.Salary.Commands.UpdateEmployee;
using Salary.Application.Features.Salary.Queries.GetEmployeesByDepartment;
using Salary.Application.Features.Salary.Queries.GetSalaryByEmployeeCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Salary.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SalaryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{employeeCode}", Name = "GetEmployeeSalaryByEmployeeCode")]
        [ProducesResponseType(typeof(IEnumerable<SalaryDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SalaryDTO>>> GetEmployeeSalaryByEmployeeCode(string employeeCode)
        {
            var query = new GetSalaryByEmployeeCodeQuery(employeeCode);
            var employeeList = await _mediator.Send(query);
            return Ok(employeeList);
        }

        [HttpPost(Name = "AddEmployeeSalary")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddEmployeeSalary([FromBody] AddEmployeeSalaryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateEmployeeSalary")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateEmployeeSalary([FromBody] UpdateEmployeeSalaryCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

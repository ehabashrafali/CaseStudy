using CaseStudy.Application.Commands.CreateEmployee;
using CaseStudy.Application.Commands.DeleteEmployee;
using CaseStudy.Application.Commands.EditEmployee;
using CaseStudy.Application.Queries.GetEmployee;
using CaseStudy.Application.Queries.GetEmployeesByHiringDate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/employees/")]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee(Guid id, [FromBody] EditEmployeeCommand command, CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id, [FromQuery] Guid version, CancellationToken cancellationToken)
        {
            var command = new DeleteEmployeeCommand(id, version);

            var result = await sender.Send(command, cancellationToken);
            return Ok(result);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeQuery(id);
            var result = await sender.Send(query, cancellationToken);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployeeByHiringDate([FromQuery] DateOnly fromHiringDate, [FromQuery] DateOnly toHiringDate, CancellationToken cancellationToken)
        {
            var result = await sender.Send(new GetEmployeesByHiringDateQuery(fromHiringDate, toHiringDate), cancellationToken);
            return Ok(result);
        }
    }
}

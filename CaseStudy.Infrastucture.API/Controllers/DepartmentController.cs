using CaseStudy.Application.Commands.CreateDepartment;
using CaseStudy.Application.Queries.GetDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Infrastructure.API.Controllers;

[ApiController]
[Route("api/departments")]

public class DepartmentController(ISender sender) : ControllerBase
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartmentById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetDepartmentQuery(id);
        var result = await sender.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        return Ok(result);
    }
}

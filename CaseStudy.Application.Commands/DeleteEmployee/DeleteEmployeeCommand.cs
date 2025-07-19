using MediatR;

namespace CaseStudy.Application.Commands.DeleteEmployee;

public class DeleteEmployeeCommand(Guid employeeId, Guid version) : IRequest<Unit>
{
    public Guid EmployeeId { get; set; } = employeeId;
    public Guid Version { get; set; } = version;
}

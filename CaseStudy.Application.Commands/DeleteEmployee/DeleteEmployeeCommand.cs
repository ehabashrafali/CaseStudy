using MediatR;

namespace CaseStudy.Application.Commands.DeleteEmployee;

public class DeleteEmployeeCommand : IRequest<Unit>
{
    public Guid EmployeeId { get; set; }
    public Guid Version { get; set; }
}

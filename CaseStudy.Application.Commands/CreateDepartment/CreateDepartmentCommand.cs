using CaseStudy.Domain.Employee;
using MediatR;

namespace CaseStudy.Application.Commands.CreateDepartment;

public class CreateDepartmentCommand : IRequest<Guid>
{
    public string Name { get; set;}
}

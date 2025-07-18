using CaseStudy.Application.Commands.CreateEmployee;
using CaseStudy.Domain.Department;
using CaseStudy.Domain.Repositories;
using MediatR;

namespace CaseStudy.Application.Commands.CreateDepartment;

public class CreateDepartmentCommandHandller(IDepartmentCommandRepository _repository_) : IRequestHandler<CreateDepartmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = new Department(request.Name, request.Employees);
        await _repository_.AddAsync(department);
        return department.Id;
    }
}

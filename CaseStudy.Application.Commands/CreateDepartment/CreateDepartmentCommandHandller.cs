using CaseStudy.Application.Commands.CreateEmployee;
using CaseStudy.Domain.Department;
using CaseStudy.Domain.Repositories;
using MediatR;

namespace CaseStudy.Application.Commands.CreateDepartment;

public class CreateDepartmentCommandHandller(IDepartmentCommandRepository _repository) : IRequestHandler<CreateDepartmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = new Department(request.Name);
        await _repository.AddAsync(department);
        return department.Id;
    }
}

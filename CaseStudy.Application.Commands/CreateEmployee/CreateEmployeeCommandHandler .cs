using CaseStudy.Domain.Employee;
using CaseStudy.Domain.Repositories;
using MediatR;

namespace CaseStudy.Application.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler(IEmployeeCommandRepository _repository) : IRequestHandler<CreateEmployeeCommand, Guid>
{

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            Name = request.Name,
            Email = request.Email,
            HireDate = request.HireDate,
            Status = request.Status
        };
        await _repository.AddAsync(employee);
        return employee.Id;
    }
}

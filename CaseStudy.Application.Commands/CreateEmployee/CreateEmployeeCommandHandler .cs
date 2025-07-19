using CaseStudy.Domain.Department;
using CaseStudy.Domain.Employee;
using CaseStudy.Domain.Logs;
using CaseStudy.Domain.Repositories;
using MediatR;

namespace CaseStudy.Application.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler(IEmployeeCommandRepository _repository, IDepartmentCommandRepository _deptrepository ) : IRequestHandler<CreateEmployeeCommand, Guid>
{

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {

        var department = await _deptrepository.GetByIdAsync(request.DepartmentId, cancellationToken);

        if (department is null)
            throw new Exception("Department not found");

        var employee = new Employee
        {
            Name = request.Name,
            Email = request.Email,
            HireDate = request.HireDate,
            Status = request.Status,
            Department = request.Department

        };
        
        var logs = new Logs(DateTime.UtcNow, null, SharedModels.ActionType.Create);
        employee.AddLogs(logs);
        await _repository.AddAsync(employee);
        return employee.Id;
    }
}

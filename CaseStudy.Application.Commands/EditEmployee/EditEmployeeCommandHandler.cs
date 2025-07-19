using CaseStudy.Domain.Exceptions;
using CaseStudy.Domain.Logs;
using CaseStudy.Domain.Repositories;
using MediatR;

namespace CaseStudy.Application.Commands.EditEmployee
{
    public class EditEmployeeCommandHandler(IEmployeeCommandRepository repository) : IRequestHandler<EditEmployeeCommand, Guid>
    {

        public async Task<Guid> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await repository.GetEmployeeById(request.Id);

            if (employee.Version != request.Version)
                throw new ConflictException("Employee has been modified by another process.");

            employee.Name = request.Name;
            employee.Email = request.Email;
            employee.HireDate = request.HireDate;
            employee.Status = request.Status;

            var logs = new Logs(null, DateTime.UtcNow, SharedModels.ActionType.update);
            employee.AddLogs(logs);

            await repository.UpdateAsync(employee);

            return employee.Id;
        }


    }
}

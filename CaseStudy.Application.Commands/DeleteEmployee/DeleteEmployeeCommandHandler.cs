using CaseStudy.Application.Commands.CreateEmployee;
using CaseStudy.Domain.Exceptions;
using CaseStudy.Domain.Logs;
using CaseStudy.Domain.Repositories;
using MediatR;

namespace CaseStudy.Application.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler(IEmployeeCommandRepository _repository) : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetEmployeeById(request.EmployeeId);

            if (employee is null)
                return Unit.Value;

            if (employee.Version != request.Version)
                    throw new ConflictException("The employee has been modified.");

            employee.SetAsDeleted();

            var logs =  new Logs(null, DateTime.UtcNow, SharedModels.ActionType.delete);
            employee.AddLogs(logs);

            await _repository.UpdateAsync(employee);
            return Unit.Value;

        }
    }
}

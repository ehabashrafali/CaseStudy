using CaseStudy.Domain.Repositories;
using MediatR;

namespace CaseStudy.Application.Commands.CreateEmployee
{
    public class CreateEmployeeCommandPreparerBehavior(IDepartmentCommandRepository _repository) : IPipelineBehavior<CreateEmployeeCommand, Guid>
    {
        public async Task<Guid> Handle(CreateEmployeeCommand request, RequestHandlerDelegate<Guid> next, CancellationToken cancellationToken)
        {
            var department = await _repository.GetByIdAsync(request.DepartmentId, cancellationToken);

            request.Department = department;

            return await next();
        }
    }
}

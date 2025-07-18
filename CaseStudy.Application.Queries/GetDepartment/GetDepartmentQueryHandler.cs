using CaseStudy.Application.Queries.Repositories;
using MediatR;

namespace CaseStudy.Application.Queries.GetDepartment;

public class GetDepartmentQueryHandler(IDepartmentQueriesRepository _repository) : IRequestHandler<GetDepartmentQuery, DepartmentDto>
{
    public async Task<DepartmentDto> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetDepartmentById(request.DepartmentId);
    }
}

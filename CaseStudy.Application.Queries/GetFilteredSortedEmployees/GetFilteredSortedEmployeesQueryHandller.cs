using CaseStudy.Application.Queries.Repositories;
using MediatR;

namespace CaseStudy.Application.Queries.GetFilteredSortedEmployees
{
    public class GetFilteredSortedEmployeesQueryHandller(IEmployeeQueriesRepository _repository) : IRequestHandler<GetFilteredSortedEmployeesQuery, List<EmployeeDto>>
    {
        public async Task<List<EmployeeDto>> Handle(GetFilteredSortedEmployeesQuery request, CancellationToken cancellationToken)
        {
           return await _repository.GetFilteredSortedEmployes(request.EmployeeFilter, request.SortingDirection);
        }
    }
}

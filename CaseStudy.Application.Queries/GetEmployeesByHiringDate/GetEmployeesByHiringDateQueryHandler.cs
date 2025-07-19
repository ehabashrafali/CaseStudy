using CaseStudy.Application.Queries.Repositories;
using MediatR;

namespace CaseStudy.Application.Queries.GetEmployeesByHiringDate
{
    public class GetEmployeesByHiringDateQueryHandler(IEmployeeQueriesRepository _repository) : IRequestHandler<GetEmployeesByHiringDateQuery, List<EmployeeDto>>
    {
        public async Task<List<EmployeeDto>> Handle(GetEmployeesByHiringDateQuery request, CancellationToken cancellationToken)
        {
           return await _repository.GetEmployeeByHiringDate(request.FromHiringDate, request.ToHiringDate, cancellationToken);

        }
    }
}

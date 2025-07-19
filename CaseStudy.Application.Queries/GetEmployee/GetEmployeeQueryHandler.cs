using CaseStudy.Application.Queries.Repositories;
using MediatR;

namespace CaseStudy.Application.Queries.GetEmployee
{
    public class GetEmployeeQueryHandler(IEmployeeQueriesRepository  _repository) : IRequestHandler<GetEmployeeQuery, EmployeeDto>
    {
        public async Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetEmployeeById(request.EmployeeId);
        }
    }
}

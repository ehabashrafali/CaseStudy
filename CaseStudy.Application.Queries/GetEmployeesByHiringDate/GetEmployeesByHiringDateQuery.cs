using CaseStudy.Application.Queries.Repositories;
using MediatR;

namespace CaseStudy.Application.Queries.GetEmployeesByHiringDate
{
    public class GetEmployeesByHiringDateQuery(DateOnly fromHiringDate, DateOnly toHiringDate) : IRequest<List<EmployeeDto>>
    {
        public DateOnly FromHiringDate { get; private set; } = fromHiringDate;
        public DateOnly ToHiringDate { get; private set; } = toHiringDate;
    }
}

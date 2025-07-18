using CaseStudy.Application.Queries.Repositories;
using CaseStudy.SharedModels;
using MediatR;

namespace CaseStudy.Application.Queries.GetFilteredSortedEmployees
{
    public record GetFilteredSortedEmployeesQuery(EmployeeFilter? EmployeeFilter, SortingDirection? SortingDirection) : IRequest<List<EmployeeDto>>;
}

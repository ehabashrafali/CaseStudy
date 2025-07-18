using CaseStudy.Application.Queries.Repositories;
using MediatR;

namespace CaseStudy.Application.Queries.GetEmployee;

public record GetEmployeeQuery(Guid EmployeeId) : IRequest<EmployeeDto>;


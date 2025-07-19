using CaseStudy.Application.Queries.Repositories;
using MediatR;

namespace CaseStudy.Application.Queries.GetDepartment;

public record GetDepartmentQuery(Guid DepartmentId) : IRequest<DepartmentDto>;

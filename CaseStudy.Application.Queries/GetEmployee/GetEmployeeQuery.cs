namespace CaseStudy.Application.Queries.GetEmployee;

public class GetEmployeeQuery(Guid employeeId) : IRequest<EmployeeDto>
{
    public Guid EmployeeId { get; } = employeeId;
}
{
}

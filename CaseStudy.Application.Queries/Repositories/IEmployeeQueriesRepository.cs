using CaseStudy.Application.Commands.CreateEmployee;
using CaseStudy.SharedModels;

namespace CaseStudy.Application.Queries.Repositories
{
    public interface IEmployeeQueriesRepository
    {
        Task<List<EmployeeDto>> GetEmployeeByHiringDate(DateOnly fromHiringDate, DateOnly toHiringDate, CancellationToken cancellationToken);
        Task<EmployeeDto> GetEmployeeById(Guid id);
        Task<List<EmployeeDto>> GetFilteredSortedEmployes(EmployeeFilter? employeeFilter, SortingDirection? sortingDirection);
    }

    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public DateOnly HireDate { get; set; }
        public EmployeeStatus Status { get; set; }
    }
}

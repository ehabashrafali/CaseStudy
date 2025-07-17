using CaseStudy.Application.Commands.CreateEmployee;
using CaseStudy.Application.Queries.Repositories;
using CaseStudy.SharedModels;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.DataBase.Employees.Repositories
{
    public class EmployeeQueriesRepository(CaseStudyDbContext _context) : IEmployeeQueriesRepository
    {
        public async Task<EmployeeDto> GetEmployeeById(Guid id)
        {
            var employee = await _context.Employees
               .Include(e => e.Department)
               .FirstOrDefaultAsync(e => e.Id == id);

            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                DepartmentId = employee.Department.Id,
                HireDate = employee.HireDate,
                Status = employee.Status,
            };
        }

        public async Task<List<EmployeeDto>> GetFilteredSortedEmployes(EmployeeFilter? employeeFilter, SortingDirection sortingDirection)
        {
            var query = _context.Employees
                            .Include(e => e.Department)
                            .AsQueryable();

            if (employeeFilter is not null)
            {
                if (!string.IsNullOrWhiteSpace(employeeFilter.Name))
                {
                    query = query.Where(e => e.Name.Contains(employeeFilter.Name));
                }

                if (employeeFilter.DepartmentId != Guid.Empty)
                {
                    query = query.Where(e => e.Department.Id == employeeFilter.DepartmentId);
                }

                if (Enum.IsDefined(typeof(EmployeeStatus), employeeFilter.EmployeeStatus))
                {
                    query = query.Where(e => e.Status == employeeFilter.EmployeeStatus);
                }
            }

            // Sorting by Name (example) - can be customized
            query = sortingDirection == SortingDirection.Ascending
                ? query.OrderBy(e => e.Name)
                : query.OrderByDescending(e => e.Name);

            var employees = await query.ToListAsync();

            return [.. employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                DepartmentId = e.Department.Id,
                HireDate = e.HireDate,
                Status = e.Status
            })];

        }
    }
}

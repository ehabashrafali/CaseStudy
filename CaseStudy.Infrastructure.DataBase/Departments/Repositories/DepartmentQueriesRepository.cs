using CaseStudy.Application.Queries.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.DataBase.Departments.Repositories
{
    public class DepartmentQueriesRepository(CaseStudyDbContext _context) : IDepartmentQueriesRepository
    {
        public async Task<DepartmentDto> GetDepartmentById(Guid id)
        {
            var dept = await _context.Departments
                .Include(d => d.Employees)
                .FirstOrDefaultAsync();

            if (dept is null)
                return new DepartmentDto();

            return new DepartmentDto
            {
                Id = dept.Id,
                Name = dept.Name,
                EmployeeDtos = [.. dept.Employees.Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    DepartmentId = e.Id,
                    HireDate = e.HireDate,
                    Status = e.Status
                })]
            };
        }
    }
}

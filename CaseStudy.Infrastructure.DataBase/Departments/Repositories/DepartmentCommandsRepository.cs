using CaseStudy.Domain.Department;
using CaseStudy.Domain.Repositories;

namespace CaseStudy.Infrastructure.DataBase.Departments.Repositories;

public class DepartmentCommandsRepository(CaseStudyDbContext _context) : IDepartmentCommandRepository
{
    public async Task AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
    }
}

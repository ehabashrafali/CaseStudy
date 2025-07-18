using CaseStudy.Domain.Department;
using CaseStudy.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.DataBase.Departments.Repositories;

public class DepartmentCommandsRepository(CaseStudyDbContext Context) : IDepartmentCommandRepository
{
    public async Task AddAsync(Department department)
    {
        await Context.Departments.AddAsync(department);
        await Context.SaveChangesAsync();
    }

    public async Task<Department> GetByIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        return await Context.Departments.FirstOrDefaultAsync(department => department.Id == departmentId, cancellationToken);
    }
}

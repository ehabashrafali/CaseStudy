namespace CaseStudy.Domain.Repositories
{
    public interface IDepartmentCommandRepository
    {
        Task AddAsync(Department.Department department);
    }
}

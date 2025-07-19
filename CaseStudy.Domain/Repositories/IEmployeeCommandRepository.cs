namespace CaseStudy.Domain.Repositories
{
    public interface IEmployeeCommandRepository
    {
        Task AddAsync(Employee.Employee employee);
        Task UpdateAsync(Employee.Employee employee);
        Task<Employee.Employee>? GetEmployeeById(Guid orderId);
    }
}

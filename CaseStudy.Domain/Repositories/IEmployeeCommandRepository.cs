using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Domain.Repositories
{
    public interface IEmployeeCommandRepository
    {
        Task AddAsync(Employee.Employee employee);
        Task UpdateAsync(Employee.Employee employee);
        Task DeleteAsync(Guid employeeId);
        Task<Employee.Employee>? GetEmployeeById(Guid orderId);
    }
}

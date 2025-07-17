using CaseStudy.Domain.Employee;
using CaseStudy.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.DataBase.Employees.Repositories
{
    public class EmployeeCommandRepository(CaseStudyDbContext _context) : IEmployeeCommandRepository
    {
        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Employee>? GetEmployeeById(Guid employeeId)
            => await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);

        public async Task UpdateAsync(Employee employee)
        {
            employee.Version = Guid.NewGuid();
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
      
    }
}

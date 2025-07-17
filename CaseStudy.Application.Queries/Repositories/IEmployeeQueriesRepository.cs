using CaseStudy.Application.Commands.CreateEmployee;
using CaseStudy.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Queries.Repositories
{
    public interface IEmployeeQueriesRepository
    {
        public Task<EmployeeDto> GetEmployeeById(Guid id);
        public Task <List<EmployeeDto>> GetFilteredSortedEmployes(EmployeeFilter? employeeFilter, SortingDirection sortingDirection);
    }

    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeStatus Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Application.Queries.Repositories
{
    public interface IDepartmentQueriesRepository
    {
        Task<DepartmentDto> GetDepartmentById(Guid id);
    }

    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<EmployeeDto> EmployeeDtos { get; set; } = [];
    }
}

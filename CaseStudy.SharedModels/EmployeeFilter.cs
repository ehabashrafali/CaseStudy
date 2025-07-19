using CaseStudy.Application.Commands.CreateEmployee;

namespace CaseStudy.SharedModels
{
    public class EmployeeFilter
    {
        public string Name { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
    }
}

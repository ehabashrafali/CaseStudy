
using CaseStudy.Domain.Department;
using MediatR;
using System.Text.Json.Serialization;

namespace CaseStudy.Application.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly HireDate { get; set; }
        public EmployeeStatus Status { get; set; }
        public Guid DepartmentId { get; set; }
        [JsonIgnore] public Department Department { get; set; }

    }

}

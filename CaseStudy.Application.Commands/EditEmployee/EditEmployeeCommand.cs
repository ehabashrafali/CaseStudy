using CaseStudy.Application.Commands.CreateEmployee;
using MediatR;

namespace CaseStudy.Application.Commands.EditEmployee
{
    public class EditEmployeeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
        public DateOnly HireDate { get; set; }
        public EmployeeStatus Status { get; set; }
        public Guid Version { get; set; }
    }
}

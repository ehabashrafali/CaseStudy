
using MediatR;

namespace CaseStudy.Application.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeStatus Status { get; set; }
    }

}

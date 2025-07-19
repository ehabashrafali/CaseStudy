using FluentValidation;

namespace CaseStudy.Application.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Status).Must(s => s == EmployeeStatus.Active || s == EmployeeStatus.Inactive).
                WithMessage("Status must be Active or Inactive.");
        }
    }
}

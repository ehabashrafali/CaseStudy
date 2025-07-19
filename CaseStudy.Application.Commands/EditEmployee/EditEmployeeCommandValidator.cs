using CaseStudy.Application.Commands.CreateEmployee;
using FluentValidation;

namespace CaseStudy.Application.Commands.EditEmployee;

public class EditEmployeeCommandValidator : AbstractValidator<EditEmployeeCommand>
{
    public EditEmployeeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.DepartmentId).NotEmpty();
        RuleFor(x => x.Status)
            .Must(s => s == EmployeeStatus.Active || s == EmployeeStatus.Inactive || s == EmployeeStatus.Terminated)
            .WithMessage("Invalid Status.");
        RuleFor(x => x.Version).NotEmpty();
    }
}

using FluentValidation;

namespace ERP.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.DepartmentId).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.HireDate).NotNull().LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(x => x.DateOfBirth).NotNull();
            RuleFor(x => x.Status).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Gender).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Salary).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(200);
            RuleFor(x => x.AvatarUrl).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MaximumLength(100);
        }
    }
}
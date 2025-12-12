using FluentValidation;

namespace ERP.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(200);
            RuleFor(x => x.AvatarUrl).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(x => x.Password).MaximumLength(100);
        }
    }
}
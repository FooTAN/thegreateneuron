using FluentValidation;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.UserName).MinimumLength(3).MaximumLength(99).NotEmpty();
            RuleFor(v => v.Password).MinimumLength(3).MaximumLength(99).NotEmpty();
        }
    }
}

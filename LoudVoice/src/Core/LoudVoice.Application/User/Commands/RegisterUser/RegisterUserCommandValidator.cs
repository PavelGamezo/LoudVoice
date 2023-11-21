using FluentValidation;

namespace LoudVoice.Application.User.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(command => command.Login)
                .NotEmpty().WithMessage("Login is required")
                .MaximumLength(100).WithMessage("Login must not be greater than 100 characters.");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid");

            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("Password is required and can't be empty")
                .Length(8, 100).WithMessage("Password must be greater than 8 and less than 100 characters");
        }
    }
}

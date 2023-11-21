using FluentValidation;

namespace LoudVoice.Application.User.Commands.DeleteUser
{
    public sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(deleteUserCommand => deleteUserCommand.UserId)
                .NotEqual(Guid.Empty)
                .WithErrorCode("UserId can't be empty");
        }
    }
}

using ErrorOr;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.DTOs;

namespace LoudVoice.Application.User.Commands.RegisterUser
{
    public record RegisterUserCommand(string Login, string Email, string Password) : ICommand<ErrorOr<UserDto>>;
}

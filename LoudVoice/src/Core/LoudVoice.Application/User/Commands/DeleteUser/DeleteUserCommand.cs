using ErrorOr;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.DTOs;
using MediatR;

namespace LoudVoice.Application.User.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid UserId) : ICommand<ErrorOr<Unit>>;
}

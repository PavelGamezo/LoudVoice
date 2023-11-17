using ErrorOr;
using LoudVoice.Application.Common.Cqrs.Queries;
using LoudVoice.Application.Common.DTOs;

namespace LoudVoice.Application.User.Queries.Login
{
    public record LoginUserQuery(string Login, string Password) : IQuery<ErrorOr<UserDto>>;
}

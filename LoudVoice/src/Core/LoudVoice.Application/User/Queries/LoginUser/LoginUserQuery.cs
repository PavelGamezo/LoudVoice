using FluentResults;
using LoudVoice.Application.Common.Cqrs.Queries;
using LoudVoice.Application.Common.DTOs;
using LoudVoice.Application.User.Commands.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.User.Queries.Login
{
    public record LoginUserQuery(string Login, string Email, string Password) : IQuery<Result<UserDto>>;
}

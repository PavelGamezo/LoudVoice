using FluentResults;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoudVoice.Application.User.Commands.RegisterUser
{
    public record RegisterUserCommand(string Login, string Email, string Password) : ICommand<Result<UserDto>>;
}

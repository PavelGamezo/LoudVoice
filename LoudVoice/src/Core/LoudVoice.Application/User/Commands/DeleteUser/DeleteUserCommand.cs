using FluentResults;
using LoudVoice.Application.Common.Cqrs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoudVoice.Application.User.Commands.DeleteUser
{
    public record DeleteUserCommand(
        Guid UserId, 
        string Login, 
        string Email, 
        string Password) : ICommand<Result>;
}

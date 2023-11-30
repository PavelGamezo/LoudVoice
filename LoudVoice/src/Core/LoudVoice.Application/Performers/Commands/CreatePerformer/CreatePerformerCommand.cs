using ErrorOr;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoudVoice.Application.Performers.Commands.CreatePerformer
{
    public record CreatePerformerCommand(
        string Nickname,
        string Description,
        Guid UserId) : ICommand<ErrorOr<PerformerDto>>;
}

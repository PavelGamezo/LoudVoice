using ErrorOr;
using LoudVoice.Application.Common.Cqrs.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoudVoice.Application.Performers.Commands.DeletePerformer
{
    public record DeletePerformerCommand(Guid performerId, Guid userId) : ICommand<ErrorOr<Unit>>
    {
    }
}

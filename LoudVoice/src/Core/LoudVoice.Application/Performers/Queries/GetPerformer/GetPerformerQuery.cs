using ErrorOr;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.Cqrs.Queries;
using LoudVoice.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoudVoice.Application.Performers.Queries.GetPerformer
{
    public record GetPerformerQuery(
        Guid Id,
        string Nickname,
        string Description,
        Guid UserId) : IQuery<ErrorOr<PerformerDto>>;
}

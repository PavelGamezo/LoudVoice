using LoudVoice.Domain.Performers.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.Common.Persistance
{
    public interface IPerformerRepository
    {
        Task<Performer> GetPerformerById(Guid id, CancellationToken cancellationToken);
        Task<Performer> GetPerformerByNickname(string nickname, CancellationToken cancellationToken);
        Task AddPerformerAsync(Performer performer, CancellationToken cancellationToken);
        Task RemovePerformerAsync(Performer performer, CancellationToken cancellationToken);
        Task UpdatePerformerAsync(Performer performer, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}

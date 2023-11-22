using LoudVoice.Domain.Compositions.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.Common.Persistance
{
    public interface ICompositionRepository
    {
        Task<Composition> GetCompositionByName(string name, CancellationToken cancellationToken);
        Task<Composition> GetCompositionById(Guid id, CancellationToken cancellationToken);
        Task AddCompositionAsync(Composition entity, CancellationToken cancellationToken);
        Task RemoveCompositionAsync(Composition entity, CancellationToken cancellationToken);
        Task UpdateCompositionAsync(Composition entity, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}

using LoudVoice.Domain.Performers;

namespace LoudVoice.Application.Common.Persistance
{
    public interface IPerformerRepository
    {
        Task<Performer> GetPerformerByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Performer> GetPerformerByNicknameAsync(string nickname, CancellationToken cancellationToken);
        Task AddPerformerAsync(Performer performer, CancellationToken cancellationToken);
        Task RemovePerformerAsync(Performer performer, CancellationToken cancellationToken);
        Task UpdatePerformerAsync(Performer performer, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}

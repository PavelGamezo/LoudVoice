using LoudVoice.Application.Common.Persistance;
using LoudVoice.Domain.Performers.Entity;
using LoudVoice.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Infrastructure.EF.Repositories
{
    public class PerformerRepository : IPerformerRepository
    {
        private readonly LoudVoiceDbContext _dbContext;
        private readonly DbSet<Performer> _performers;

        public PerformerRepository(LoudVoiceDbContext dbContext)
        {
            _dbContext = dbContext;
            _performers = dbContext.Performers;
        }

        public async Task AddPerformerAsync(Performer performer, CancellationToken cancellationToken)
        {
            await _performers.AddAsync(performer, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public Task<Performer> GetPerformerById(Guid id, CancellationToken cancellationToken)
        {
            return _performers.FirstOrDefaultAsync(performer => performer.Id == id, cancellationToken);
        }

        public Task<Performer> GetPerformerByNickname(string nickname, CancellationToken cancellationToken)
        {
            return _performers.FirstOrDefaultAsync(performer => performer.Nickname == nickname, cancellationToken);
        }

        public async Task RemovePerformerAsync(Performer performer, CancellationToken cancellationToken)
        {
            _performers.Remove(performer);
            await SaveAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdatePerformerAsync(Performer performer, CancellationToken cancellationToken)
        {
            _performers.Update(performer);
            await SaveAsync(cancellationToken);
        }
    }
}

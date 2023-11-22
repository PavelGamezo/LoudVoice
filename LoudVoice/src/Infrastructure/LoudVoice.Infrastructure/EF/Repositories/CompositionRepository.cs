using LoudVoice.Application.Common.Persistance;
using LoudVoice.Domain.Compositions.Entity;
using LoudVoice.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Infrastructure.EF.Repositories
{
    public class CompositionRepository : ICompositionRepository
    {
        private LoudVoiceDbContext _dbContext;
        private DbSet<Composition> _compositions;

        public CompositionRepository(LoudVoiceDbContext dbContext)
        {
            _dbContext = dbContext;
            _compositions = dbContext.Compositions;
        }

        public async Task AddCompositionAsync(Composition entity, CancellationToken cancellationToken)
        {
            await _compositions.AddAsync(entity, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public Task<Composition> GetCompositionById(Guid id, CancellationToken cancellationToken)
        {
            return _compositions.SingleOrDefaultAsync(composition => composition.Id == id);
        }

        public Task<Composition> GetCompositionByName(string name, CancellationToken cancellationToken)
        {
            return _compositions.SingleOrDefaultAsync(composition => composition.Name == name);
        }

        public async Task RemoveCompositionAsync(Composition entity, CancellationToken cancellationToken)
        {
            _compositions.Remove(entity);
            await SaveAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCompositionAsync(Composition entity, CancellationToken cancellationToken)
        {
            _compositions.Update(entity);
            await SaveAsync(cancellationToken);
        }
    }
}

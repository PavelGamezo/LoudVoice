using LoudVoice.Application.Common.Persistance;
using LoudVoice.Domain.Users.Entity;
using LoudVoice.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Infrastructure.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LoudVoiceDbContext _dbContext;
        private readonly DbSet<User> _users;

        public UserRepository(LoudVoiceDbContext dbContext)
        {
            _dbContext = dbContext;
            _users = _dbContext.Users;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _users.AddAsync(user, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public async Task DeleteAsync(User user, CancellationToken cancellationToken)
        {
            _users.Remove(user);
            await SaveAsync(cancellationToken);
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken) 
            => await _users.SingleOrDefaultAsync(user => user.Email == email);

        public async Task<User?> GetUserByLoginAsync(string login, CancellationToken cancellationToken) 
            => await _users.SingleOrDefaultAsync(user => user.Login == login);

        public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
            => await _users.SingleOrDefaultAsync(user => user.Id == userId);

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            _users.Update(user);
            await SaveAsync(cancellationToken);
        }
    }
}

namespace LoudVoice.Application.Common.Persistance
{
    public interface IUserRepository
    {
        Task<Domain.Users.Entity.User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task AddAsync(Domain.Users.Entity.User user, CancellationToken cancellationToken);
        Task UpdateAsync(Domain.Users.Entity.User user, CancellationToken cancellationToken);
        Task DeleteAsync(Domain.Users.Entity.User user, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}

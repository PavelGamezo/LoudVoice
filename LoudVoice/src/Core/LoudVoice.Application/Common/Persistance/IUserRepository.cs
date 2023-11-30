namespace LoudVoice.Application.Common.Persistance
{
    public interface IUserRepository
    {
        Task<Domain.Users.User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<Domain.Users.User?> GetUserByLoginAsync(string login, CancellationToken cancellationToken);
        Task<Domain.Users.User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task AddAsync(Domain.Users.User user, CancellationToken cancellationToken);
        Task UpdateAsync(Domain.Users.User user, CancellationToken cancellationToken);
        Task DeleteAsync(Domain.Users.User user, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}

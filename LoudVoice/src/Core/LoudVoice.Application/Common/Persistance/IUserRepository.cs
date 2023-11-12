namespace LoudVoice.Application.Common.Persistance
{
    public interface IUserRepository
    {
        Task<Domain.Users.Entity.User> GetUserByEmailAsync(string email);
        Task AddAsync(Domain.Users.Entity.User user);
        Task UpdateAsync(Domain.Users.Entity.User user);
        Task DeleteAsync(Domain.Users.Entity.User user);
    }
}

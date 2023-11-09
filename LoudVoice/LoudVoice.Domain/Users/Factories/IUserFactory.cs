using LoudVoice.Domain.Users.Entities;

namespace LoudVoice.Domain.Users.Factories
{
    public interface IUserFactory
    {
        User Create(Guid id, string login, string email, string password);
    }
}

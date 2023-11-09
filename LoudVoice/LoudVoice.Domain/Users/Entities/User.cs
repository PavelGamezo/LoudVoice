using LoudVoice.Domain.Common.Domain;
using LoudVoice.Domain.Users.Events;

namespace LoudVoice.Domain.Users.Entities
{
    public class User : AggregateRoot
    {
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        internal User(Guid id, string login, string email, string password) : base(id)
        {
            Login = login;
            Email = email;
            Password = password;

            AddDomainEvent(new UserCreatedDomainEvent(this));
        }


    }
}

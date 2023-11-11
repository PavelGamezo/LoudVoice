using LoudVoice.Domain.Common;
using LoudVoice.Domain.Users.ValueObjects;

namespace LoudVoice.Domain.Users.Entity
{
    public class User : AggregateRoot
    {
        public Login Login { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        
        internal User(Guid id, string login, string email, string password) : base(id)
        {
            Login = login;
            Email = email;
            Password = password;
        }
    }
}

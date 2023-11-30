using ErrorOr;
using LoudVoice.Domain.Common;
using LoudVoice.Domain.Performers;
using LoudVoice.Domain.Users.Errors;
using LoudVoice.Domain.Users.ValueObjects;

namespace LoudVoice.Domain.Users
{
    public class User : AggregateRoot<Guid>
    {
        public Login Login { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }

        private Performer? Performer { get; set; }

        internal User(Guid id, string login, string email, string password) : base(id)
        {
            Login = login;
            Email = email;
            Password = password;
        }

        private User(Guid id) : base(id)
        {

        }

        public ErrorOr<Performer> GetPerformer(Guid performerId)
        {
            if (Performer is null || Performer.Id != performerId)
            {
                return UserDomainErrors.PerformerNotExist;
            }

            return Performer;
        }
    }
}

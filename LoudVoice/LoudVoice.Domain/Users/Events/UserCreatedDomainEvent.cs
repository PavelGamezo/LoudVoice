using LoudVoice.Domain.Common.Domain;
using LoudVoice.Domain.Users.Entities;

namespace LoudVoice.Domain.Users.Events
{
    internal class UserCreatedDomainEvent : IDomainEvent
    {
        public User User { get; set; }

        public UserCreatedDomainEvent(User user)
        {
            User = user;
        }
    }
}

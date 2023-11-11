using LoudVoice.Domain.Common;
using LoudVoice.Domain.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Users.Events
{
    public class UserCreatedDomainEvent : IDomainEvent
    {
        public User User { get; init; }

        public UserCreatedDomainEvent(User user)
        {
            User = user;
        }
    }
}

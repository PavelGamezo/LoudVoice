using LoudVoice.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Users.Factories
{
    public sealed class UserFactory : IUserFactory
    {
        public User Create(Guid id, string login, string email, string password) =>
            new(id, login, email, password);
    }
}

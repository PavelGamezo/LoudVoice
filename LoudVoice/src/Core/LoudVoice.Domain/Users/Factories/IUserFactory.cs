using LoudVoice.Domain.Users.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Domain.Users.Factories
{
    public interface IUserFactory
    {
        User Create(Guid id,  string login, string email, string password);
    }
}

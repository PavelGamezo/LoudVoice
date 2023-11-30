using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.User.Common
{
    public record AuthenticationResult(Guid Id, string Login, string Email, string Password, string Token);
}

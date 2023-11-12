using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.Common.DTOs
{
    public record UserDto(Guid Id, string Login, string Email, string Password, string Token);
}

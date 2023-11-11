using LoudVoice.Domain.Users.Entity;

namespace LoudVoice.Application.Common.Authentications
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}

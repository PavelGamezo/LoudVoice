namespace LoudVoice.Application.Common.Authentications
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(Domain.Users.Entity.User user);
    }
}

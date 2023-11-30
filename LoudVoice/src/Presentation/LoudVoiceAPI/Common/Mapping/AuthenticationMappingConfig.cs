using LoudVoice.Application.Performers.Queries.GetPerformer;
using LoudVoice.Application.User.Commands.RegisterUser;
using LoudVoice.Application.User.Queries.Login;
using LoudVoiceAPI.Performers;
using LoudVoiceAPI.Users;
using Mapster;

namespace LoudVoiceAPI.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterUserRequest, RegisterUserCommand>();
            config.NewConfig<LoginUserRequest, LoginUserQuery>();
            config.NewConfig<PerformerRequest, GetPerformerQuery>();
            config.NewConfig<PerformerRequest, GetPerformerQuery>();
        }
    }
}

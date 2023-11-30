using LoudVoice.Application.Common.DTOs;
using Mapster;

namespace LoudVoice.Application.Common.Mapping
{
    public sealed class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(Domain.Users.User User, string token), UserDto>()
                .Map(dest => dest.Id, src => src.User.Id)
                .Map(dest => dest.Login, src => src.User.Login.Value)
                .Map(dest => dest.Password, src => src.User.Password.Value)
                .Map(dest => dest.Email, src => src.User.Email.Value)
                .Map(dest => dest.Email, src => src.token);

            config.NewConfig<Domain.Users.User, UserDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Login, src => src.Login.Value)
                .Map(dest => dest.Password, src => src.Password.Value)
                .Map(dest => dest.Email, src => src.Email.Value);
        }
    }
}

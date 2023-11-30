using LoudVoice.Application.Common.DTOs;
using LoudVoice.Domain.Performers;
using Mapster;

namespace LoudVoice.Application.Common.Mapping
{
    public sealed class PerformerMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Performer, PerformerDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nickname, src => src.Nickname)
                .Map(dest => dest.Description, src => src.Description);
        }
    }
}

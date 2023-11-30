using ErrorOr;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.DTOs;
using LoudVoice.Application.Common.Errors;
using LoudVoice.Application.Common.Persistance;
using LoudVoice.Domain.Performers.Factories;
using LoudVoice.Domain.Performers.ValueObjects;
using MapsterMapper;
using MediatR;

namespace LoudVoice.Application.Performers.Commands.CreatePerformer
{
    public sealed class CreatePerformerCommandHandler 
        : ICommandHandler<CreatePerformerCommand, ErrorOr<PerformerDto>>
    {
        private readonly IPerformerRepository _performerRepository;
        private readonly IPerformerFactory _performerFactory;
        private readonly IMapper _mapper;

        public CreatePerformerCommandHandler(
            IPerformerRepository performerRepository, 
            IPerformerFactory performerFactory,
            IMapper mapper)
        {
            _performerRepository = performerRepository;
            _performerFactory = performerFactory;
            _mapper = mapper;
        }

        public async Task<ErrorOr<PerformerDto>> Handle(CreatePerformerCommand request, CancellationToken cancellationToken)
        {
            // Check if performer has exist
            var (nickname, description, userId) = request;

            if (await _performerRepository.GetPerformerByNicknameAsync(nickname,
                cancellationToken) is not null)
            {
                return ApplicationErrors.PerformerWithDataExist;
            }

            // Create new Performer
            var performer = _performerFactory.Create(nickname, description, userId);

            await _performerRepository.AddPerformerAsync(performer, cancellationToken);

            // Send response
            return _mapper.Map<PerformerDto>(performer);
        }
    }
}

using ErrorOr;
using LoudVoice.Application.Common.Cqrs.Queries;
using LoudVoice.Application.Common.DTOs;
using LoudVoice.Application.Common.Errors;
using LoudVoice.Application.Common.Persistance;
using MapsterMapper;

namespace LoudVoice.Application.Performers.Queries.GetPerformer
{
    public record GetPerformerQueryHandler : IQueryHandler<GetPerformerQuery, ErrorOr<PerformerDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPerformerRepository _performerRepository;
        private readonly IMapper _mapper;

        public GetPerformerQueryHandler(
            IUserRepository userRepository,
            IPerformerRepository performerRepository,
            IMapper mapper)
        {
            _performerRepository = performerRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<PerformerDto>> Handle(GetPerformerQuery request, CancellationToken cancellationToken)
        {
            var (performerId, nickname, description, userId) = request;

            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
            
            if (user is null)
            {
                return ApplicationErrors.UserNotFound;
            }

            var performer = user.GetPerformer(performerId);

            if (performer.IsError)
            {
                return performer.Errors;
            }

            return _mapper.Map<PerformerDto>(performer);
        }
    }
}

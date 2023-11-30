using ErrorOr;
using LoudVoice.Application.Common.Authentications;
using LoudVoice.Application.Common.Cqrs.Queries;
using LoudVoice.Application.Common.DTOs;
using LoudVoice.Application.Common.Errors;
using LoudVoice.Application.Common.Persistance;
using LoudVoice.Application.User.Queries.Login;
using MapsterMapper;

namespace LoudVoice.Application.User.Queries.LoginUser
{
    public class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, ErrorOr<UserDto>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserQueryHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }

        public async Task<ErrorOr<UserDto>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByLoginAsync(
                request.Login, cancellationToken).Result is not Domain.Users.User user ||
                user.Login != request.Login || user.Password != request.Password)
            {
                return ApplicationErrors.InvalidAuthentication;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new UserDto(
                user.Id, 
                user.Login, 
                user.Email, 
                user.Password, 
                token);
        }
    }
}

using ErrorOr;
using LoudVoice.Application.Common.Authentications;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.DTOs;
using LoudVoice.Application.Common.Errors;
using LoudVoice.Application.Common.Persistance;
using LoudVoice.Domain.Users.Factories;

namespace LoudVoice.Application.User.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, ErrorOr<UserDto>>
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterUserCommandHandler(
            IUserFactory userFactory,
            IUserRepository userRepository, 
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<UserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Check if user already exist
            var (login, email, password) = request;

            if (_userRepository.GetUserByEmailAsync(
                email, cancellationToken).Result is not null &&
                _userRepository.GetUserByLoginAsync(
                login, cancellationToken).Result is not null)
            {
                return ApplicationErrors.UserExist;
            }

            // Create new user account
            var userId = Guid.NewGuid();

            var user = _userFactory.Create(userId, login, email, password);

            await _userRepository.AddAsync(user, cancellationToken);

            // Generate and send jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new UserDto(userId, user.Login, user.Email, user.Password, token); 
        }
    }
}

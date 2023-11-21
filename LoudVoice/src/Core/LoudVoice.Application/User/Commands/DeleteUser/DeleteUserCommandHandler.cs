using ErrorOr;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.Errors;
using LoudVoice.Application.Common.Persistance;
using LoudVoice.Domain.Users.Factories;
using MediatR;

namespace LoudVoice.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, ErrorOr<Unit>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserFactory userFactory, IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);

            if (user is null)
            {
                return ApplicationErrors.UserNotFound;
            }

            await _userRepository.DeleteAsync(user, cancellationToken);

            return Unit.Value;
        }
    }
}

using ErrorOr;
using FluentResults;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.DTOs;
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
            var fakeUser = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

            if (fakeUser is not null)
            {
                await _userRepository.DeleteAsync(fakeUser, cancellationToken);
            }

            return Unit.Value;
        }
    }
}

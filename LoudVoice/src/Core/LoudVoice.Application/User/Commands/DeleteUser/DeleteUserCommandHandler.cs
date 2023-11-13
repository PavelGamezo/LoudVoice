using FluentResults;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.Persistance;
using LoudVoice.Domain.Users.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, Result>
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserFactory userFactory, IUserRepository userRepository)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var fakeUser = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

            if (fakeUser is not null)
            {
                await _userRepository.DeleteAsync(fakeUser, cancellationToken);
            }

            return Result.Ok();
        }
    }
}

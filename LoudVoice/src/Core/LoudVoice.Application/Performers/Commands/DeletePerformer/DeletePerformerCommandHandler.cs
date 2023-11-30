using ErrorOr;
using LoudVoice.Application.Common.Cqrs.Commands;
using LoudVoice.Application.Common.Errors;
using LoudVoice.Application.Common.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Application.Performers.Commands.DeletePerformer
{
    public class DeletePerformerCommandHandler : ICommandHandler<DeletePerformerCommand, ErrorOr<Unit>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPerformerRepository _performerRepository;

        public async Task<ErrorOr<Unit>> Handle(DeletePerformerCommand request, CancellationToken cancellationToken)
        {
            var (userId, performerId) = request;

            // Get current user and check it
            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);

            if (user is null)
            {
                return ApplicationErrors.UserNotFound;
            }

            // Get needed performer
            var performerResult = user.GetPerformer(performerId);
            if (performerResult.IsError)
            {
                return performerResult.Errors;
            }

            // Remove performer
            await _performerRepository.RemovePerformerAsync(performerResult.Value, cancellationToken);

            return Unit.Value;
        }
    }
}

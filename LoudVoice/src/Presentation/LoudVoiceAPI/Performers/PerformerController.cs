using ErrorOr;
using LoudVoice.Application.Common.DTOs;
using LoudVoice.Application.Performers.Commands.CreatePerformer;
using LoudVoice.Application.Performers.Commands.DeletePerformer;
using LoudVoice.Application.Performers.Queries.GetPerformer;
using LoudVoiceAPI.Common.Error;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoudVoiceAPI.Performers
{
    [Route("api/[controller]")]
    public class PerformerController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public PerformerController(ISender sender, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = sender;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPerformer(
            [FromQuery] PerformerRequest request,
            [FromQuery] Guid performerId,
            [FromQuery] Guid userId)
        {
            var query = new GetPerformerQuery(
                performerId,
                request.Nickname,
                request.Description,
                userId);

            ErrorOr<PerformerDto> queryResult = await _mediator.Send(query);

            return queryResult.Match(
                queryResultValue => Ok(queryResultValue),
                errors => Problem(errors));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePerformer(
            [FromQuery] PerformerRequest request,
            [FromQuery] Guid userId)
        {
            var command = new CreatePerformerCommand(
                request.Nickname,
                request.Description,
                userId);

            ErrorOr<PerformerDto> commandResult = await _mediator.Send(command);

            return commandResult.Match(
                commandResultValue => Ok(commandResultValue),
                errors => Problem(errors));
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemovePerformer(
            [FromRoute] Guid performerId,
            [FromRoute] Guid userId)
        {
            var command = new DeletePerformerCommand(performerId, userId);

            ErrorOr<Unit> commandResult = await _mediator.Send(command);

            return commandResult.Match(
                commandResultValue => Ok(commandResultValue),
                errors => Problem(errors));
        }
    }
}

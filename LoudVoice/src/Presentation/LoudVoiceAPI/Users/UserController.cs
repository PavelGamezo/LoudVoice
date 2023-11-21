using ErrorOr;
using LoudVoice.Application.Common.DTOs;
using LoudVoice.Application.User.Commands.DeleteUser;
using LoudVoice.Application.User.Commands.RegisterUser;
using LoudVoice.Application.User.Queries.Login;
using LoudVoiceAPI.Common.Error;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoudVoiceAPI.Users
{
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UserController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        /// <summary>
        /// Login user
        /// </summary>
        /// <returns></returns>
        [Route("Login")]
        [HttpGet]
        public async Task<IActionResult> LoginUser(
            [FromQuery] LoginUserRequest request)
        {
            var query = _mapper.Map<LoginUserQuery>(request);
            ErrorOr<UserDto> loginResult = await _mediator.Send(query);

            return loginResult.Match(
                loginResultValue => Ok(loginResultValue),
                errors => Problem(errors));
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <returns></returns>
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(
            [FromBody] RegisterUserRequest request)
        {
            var command = _mapper.Map<RegisterUserCommand>(request);
            ErrorOr<UserDto> registerResult = await _mediator.Send(command);

            return registerResult.Match(
                registerResultValue => Ok(registerResultValue),
                errors => Problem(errors));
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("Remove")]
        [HttpDelete]
        public async Task<IActionResult> RemoveUser(
            [FromQuery] Guid userId)
        {
            ErrorOr<Unit> deleteResult = await _mediator.Send(new DeleteUserCommand(userId));

            return deleteResult.Match(
                deleteResultValue =>  Ok(deleteResultValue),
                errors => Problem(errors));
        }
    }
}


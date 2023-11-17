using ErrorOr;
using LoudVoice.Application.Common.DTOs;
using LoudVoice.Application.User.Commands.RegisterUser;
using LoudVoice.Application.User.Queries.Login;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoudVoiceAPI.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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
                errors => Problem(statusCode: StatusCodes.Status401Unauthorized, title: errors.First().Description));
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
                errors => Problem(statusCode: StatusCodes.Status401Unauthorized, title: errors.First().Description));
        }
    }
}


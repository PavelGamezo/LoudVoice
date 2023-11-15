using ErrorOr;
using LoudVoice.Application.Common.DTOs;
using LoudVoice.Application.User.Commands.RegisterUser;
using LoudVoice.Application.User.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoudVoiceAPI.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
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
            ErrorOr<UserDto> loginResult = await _mediator.Send(new LoginUserQuery(request.login,
                                                                                   request.email,
                                                                                   request.password));

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
            ErrorOr<UserDto> registerResult = await _mediator.Send(new RegisterUserCommand(request.Login,
                                                                                           request.Email,
                                                                                           request.Password));

            return registerResult.Match(
                registerResultValue => Ok(registerResultValue),
                errors => Problem(statusCode: StatusCodes.Status401Unauthorized, title: errors.First().Description));
        }
    }
}


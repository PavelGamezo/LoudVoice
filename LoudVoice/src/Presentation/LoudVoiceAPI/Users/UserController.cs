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

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> LoginUser(
            [FromBody] LoginUserRequest request)
        {
            var tokenResult = await _mediator.Send(new LoginUserQuery(request.login, request.email, request.password));

            if (tokenResult is not null && tokenResult.IsSuccess)
            {
                return Ok(tokenResult.Value);
            }

            return BadRequest(tokenResult);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(
            [FromBody] RegisterUserRequest request)
        {
            var registerResult = await _mediator.Send(new RegisterUserCommand(request.Login, request.Email, request.Password));

            if (registerResult is not null && registerResult.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(registerResult);
        }
    }
}


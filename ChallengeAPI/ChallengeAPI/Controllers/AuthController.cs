using ChallengeAPI.Application.Commands.Request;
using ChallengeAPI.Application.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> SignIn([FromBody] SignInRequest command)
        {
            try
            {
                var response = await _mediator.Send(command);
                if (response is null)
                    return Unauthorized(new { message = "Username or Password is incorrect!" });

                return Ok(response);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new SignInNotification { Username = command.Username, Message = "FATAL ERROR" });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return BadRequest();
            }
        }

    }
}

using AuthShield.Application.Contracts.Infrastructure;
using AuthShield.Application.Features.Auth.Command.RegisterUser;
using AuthShield.Application.Features.Auth.Query.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace AuthShield.Api.Controllers.Auth
{
    [Route("api/client")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register-user", Name = "Create User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<object>> RegisterUserAsync(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("get-all-users", Name = "Get All Users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<object>> GetAllUsersAsync()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }
    }
}


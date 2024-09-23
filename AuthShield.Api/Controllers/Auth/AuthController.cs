using AuthShield.Application.Features.Auth.Command.ForgetPassword;
using AuthShield.Application.Features.Auth.Command.LogIn;
using AuthShield.Application.Features.Auth.Command.LogOut;
using AuthShield.Application.Features.Auth.Command.RegisterUser;
using AuthShield.Application.Features.Auth.Command.ResetPassword;
using AuthShield.Application.Features.Auth.Query.GetAllUsers;
using AuthShield.Persistance;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthShield.Api.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly ApplicationDbContext _context;

        public AuthController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost("register-user", Name = "Create User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<object>> RegisterUserAsync(RegisterCommand command)
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

        [HttpPost("login", Name = "User Log In")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var result = await _mediator.Send(loginCommand);
            if (result.IsSuccess)
                return Ok(result);
            return Unauthorized(result);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] LogoutCommand logoutCommand)
        {
            var result = await _mediator.Send(logoutCommand);
            return Ok(result);
        }

        [HttpPost("forgot-password", Name = "Forgot Password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgetPasswordCommand forgotPasswordCommand)
        {
            var result = await _mediator.Send(forgotPasswordCommand);
            return Ok(result);
        }

        [HttpPost("reset-password", Name = "Reset Password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand resetPasswordCommand)
        {
            var result = await _mediator.Send(resetPasswordCommand);
            return Ok(result);
        }
    }
}


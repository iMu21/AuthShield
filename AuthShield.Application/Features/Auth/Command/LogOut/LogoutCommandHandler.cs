using AuthShield.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthShield.Application.Features.Auth.Command.LogOut
{
    internal class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResponse>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<LogoutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _signInManager.SignOutAsync();
                return new LogoutResponse { IsSuccess = true, Message = "Successfully logged out" };
            }
            catch
            {
                return new LogoutResponse { IsSuccess = false, Message = "Logout Failed" };
            }
        }
    }
}

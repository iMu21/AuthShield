using AuthShield.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthShield.Application.Features.Auth.Command.ResetPassword
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPasswordHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
            {
                return new ResetPasswordResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }

            var resetResult = await _userManager.ResetPasswordAsync(user, command.Token, command.NewPassword);

            if (!resetResult.Succeeded)
            {
                return new ResetPasswordResponse
                {
                    IsSuccess = false,
                    Message = string.Join(", ", resetResult.Errors.Select(e => e.Description))
                };
            }

            return new ResetPasswordResponse
            {
                IsSuccess = true,
                Message = "Password has been reset successfully"
            };
        }
    }
}

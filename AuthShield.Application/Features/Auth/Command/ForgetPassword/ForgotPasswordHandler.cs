using AuthShield.Application.Constants;
using AuthShield.Application.Contracts.Infrastructure;
using AuthShield.Application.Model;
using AuthShield.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthShield.Application.Features.Auth.Command.ForgotPassword
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;

        public ForgotPasswordHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
            {
                return new ForgotPasswordResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }

            var resetToken = await _userManager.GenerateUserTokenAsync(user, GlobalConstants.NumericPasswordResetTokenProvider, "ResetPassword");

            var email = new Email()
            {
                Body = $"Your password reset token is {resetToken}",
                Subject = "Password Reset Token",
                To = command.Email
            };

            await _emailService.SendEmailAsync(email);

            return new ForgotPasswordResponse
            {
                IsSuccess = true,
                Message = "Password reset token has been sent to your email successfully"
            };
        }
    }
}

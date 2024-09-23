using AuthShield.Application.Constants;
using AuthShield.Application.Contracts.Infrastructure;
using AuthShield.Application.Model;
using AuthShield.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthShield.Application.Features.Auth.Command.ForgetPassword
{
    public class ForgetPasswordHandler : IRequestHandler<ForgetPasswordCommand, ForgetPasswordResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;

        public ForgetPasswordHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<ForgetPasswordResponse> Handle(ForgetPasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
            {
                return new ForgetPasswordResponse
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

            return new ForgetPasswordResponse
            {
                IsSuccess = true,
                Message = "Password reset token has been sent to your email successfully"
            };
        }
    }
}

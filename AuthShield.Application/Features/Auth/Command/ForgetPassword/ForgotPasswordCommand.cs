using MediatR;

namespace AuthShield.Application.Features.Auth.Command.ForgotPassword
{
    public class ForgotPasswordCommand: IRequest<ForgotPasswordResponse>
    {
        public string Email { get; set; } = string.Empty;
    }
}

using MediatR;

namespace AuthShield.Application.Features.Auth.Command.ForgetPassword
{
    public class ForgetPasswordCommand: IRequest<ForgetPasswordResponse>
    {
        public string Email { get; set; } = string.Empty;
    }
}

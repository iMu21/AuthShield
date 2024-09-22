using MediatR;

namespace AuthShield.Application.Features.Auth.Command.LogOut
{
    public class LogoutCommand : IRequest<LogoutResponse>
    {
    }
}

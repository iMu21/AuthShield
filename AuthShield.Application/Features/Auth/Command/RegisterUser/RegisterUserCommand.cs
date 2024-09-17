using MediatR;

namespace AuthShield.Application.Features.Auth.Command.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

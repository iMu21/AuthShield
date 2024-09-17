namespace AuthShield.Application.Features.Auth.Command.RegisterUser
{
    public class RegisterUserResponse : Responses.BaseResponse
    {
        public RegisterUserResponse() : base() { }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}

namespace AuthShield.Application.Features.Auth.Command.RegisterUser
{
    public class RegisterResponse : Responses.BaseResponse
    {
        public RegisterResponse() : base() { }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}

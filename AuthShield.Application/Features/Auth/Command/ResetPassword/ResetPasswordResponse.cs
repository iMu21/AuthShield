namespace AuthShield.Application.Features.Auth.Command.ResetPassword
{
    public class ResetPasswordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}

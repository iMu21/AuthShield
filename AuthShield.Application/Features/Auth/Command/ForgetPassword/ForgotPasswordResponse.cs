namespace AuthShield.Application.Features.Auth.Command.ForgotPassword
{
    public class ForgotPasswordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ResetToken { get; set; } = string.Empty;
    }
}

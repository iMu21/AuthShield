namespace AuthShield.Application.Features.Auth.Command.ForgetPassword
{
    public class ForgetPasswordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ResetToken { get; set; } = string.Empty;
    }
}

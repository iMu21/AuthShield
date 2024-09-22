namespace AuthShield.Application.Features.Auth.Command.LogOut
{
    public class LogoutResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}

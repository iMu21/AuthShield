namespace AuthShield.Application.Features.Auth.Query.GetAllUsers
{
    public class UserVm
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

using AuthShield.Domain.Common;

namespace AuthShield.Domain.Entities
{
    public class User : Auditable
    {
        public long Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
    }
}

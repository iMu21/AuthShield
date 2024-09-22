using Microsoft.AspNetCore.Identity;

namespace AuthShield.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? LastLogin { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateUtc { get; set; }
    }
}

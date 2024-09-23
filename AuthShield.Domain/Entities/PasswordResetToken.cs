namespace AuthShield.Domain.Entities
{
    public class PasswordResetToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; } // Navigation property
        public DateTime ExpiryDate { get; set; }
        public bool IsUsed { get; set; }
    }

}

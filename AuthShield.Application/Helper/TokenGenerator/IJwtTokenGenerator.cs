using AuthShield.Domain.Entities;

namespace AuthShield.Application.Helper.TokenGenerator
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}

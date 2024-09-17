namespace AuthShield.Application.Helper.TokenGenerator
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string email);
    }
}

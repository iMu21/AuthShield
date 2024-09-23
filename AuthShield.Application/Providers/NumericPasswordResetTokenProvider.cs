using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AuthShield.Application.Providers
{
    public class NumericPasswordResetTokenProvider<TUser> : IUserTwoFactorTokenProvider<TUser> where TUser : class
    {
        public NumericPasswordResetTokenProvider(IOptions<IdentityOptions> options, ILogger<NumericPasswordResetTokenProvider<TUser>> logger)
        {
        }

        public Task<string> GenerateAsync(string purpose, UserManager<TUser> manager, TUser user)
        {
            var random = new Random();
            string token = random.Next(10000000, 99999999).ToString();
            return Task.FromResult(token);
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser> manager, TUser user)
        {
            if (token.Length == 8 && int.TryParse(token, out _))
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(true);
        }
    }
}

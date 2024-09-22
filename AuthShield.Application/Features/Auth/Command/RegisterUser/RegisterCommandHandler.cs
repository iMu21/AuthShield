using AuthShield.Application.Helper.TokenGenerator;
using AuthShield.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthShield.Application.Features.Auth.Command.RegisterUser
{
    public class RegisterCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(command.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var user = new ApplicationUser
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserName = command.UserName,
                CreatedDateUtc = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new RegisterUserResponse { Email = user.Email, Token = token };
        }

    }
}

using AuthShield.Application.Helper.TokenGenerator;
using AuthShield.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthShield.Application.Features.Auth.Command.LogIn
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return new LoginResponse { IsSuccess = false, Message = "Invalid email or password" };

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return new LoginResponse { IsSuccess = false, Message = "Invalid login attempt" };

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new LoginResponse { IsSuccess = true, Message = "Login successful", Token = token };
        }
    }
}

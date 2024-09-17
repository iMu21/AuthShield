using AuthShield.Application.Contracts.Persistance;
using AuthShield.Application.Helper.TokenGenerator;
using AuthShield.Domain.Entities;
using MediatR;

namespace AuthShield.Application.Features.Auth.Command.RegisterUser
{
    public class RegisterCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWork.Users.GetFirstOrDefaultEntityAsync(u => u.Email == command.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);

            var user = new User
            {
                Email = command.Email,
                PasswordHash = passwordHash,
                FullName = command.FullName,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Users.InsertAsync(user);
            await _unitOfWork.SaveChangesAsync(true);

            var token = _jwtTokenGenerator.GenerateToken(command.Email);

            return new RegisterUserResponse { Email = command.Email, Token = token };
        }

    }
}

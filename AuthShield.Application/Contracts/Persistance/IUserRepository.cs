using AuthShield.Domain.Entities;

namespace AuthShield.Application.Contracts.Persistance
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
    }
}

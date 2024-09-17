using AuthShield.Application.Contracts.Persistance;
using AuthShield.Domain.Entities;
using AuthShield.Persistance.Factories;

namespace AuthShield.Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDbContextFactory<ApplicationDbContext> dBContextFactory) :
            base(dBContextFactory.CreateDbContext())
        {

        }
    }
}

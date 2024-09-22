using AuthShield.Application.Contracts.Persistance;
using AuthShield.Persistance.Factories;

namespace AuthShield.Persistance.Repositories
{
    public class RoleRepository : Repository<ApplicationRole>, IRoleRepository
    {
        public RoleRepository(IDbContextFactory<ApplicationDbContext> dBContextFactory) :
            base(dBContextFactory.CreateDbContext())
        {

        }
    }
}

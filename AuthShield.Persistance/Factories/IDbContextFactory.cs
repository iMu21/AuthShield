using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Persistance.Factories
{
    public interface IDbContextFactory<TDbContext> where TDbContext : class
    {
        TDbContext CreateDbContext();
    }
}

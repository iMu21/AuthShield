using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Persistance.Factories
{
    public class SqlDbContextFactory<TDbContext> : IDbContextFactory<TDbContext> where TDbContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;

        public SqlDbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TDbContext CreateDbContext()
        {
            return _serviceProvider.GetRequiredService<TDbContext>();
        }
    }
}

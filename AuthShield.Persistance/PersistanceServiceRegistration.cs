using AuthShield.Application.Contracts.Persistance;
using AuthShield.Persistance.Repositories;
using AuthShield.Persistance.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthShield.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices<TDbContext>(this IServiceCollection services, IConfiguration configuration)
            where TDbContext : DbContext
        {

            string? sqlConnection = configuration.GetConnectionString("ApplicationDBConnection");
            if (string.IsNullOrEmpty(sqlConnection))
                throw new InvalidOperationException("Application DB connection is missing");

            Action<DbContextOptionsBuilder> configure = options => options.UseSqlServer(sqlConnection);
            services.AddDbContext<TDbContext>(configure);

            services.AddScoped<Factories.IDbContextFactory<TDbContext>, Factories.SqlDbContextFactory<TDbContext>>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork<TDbContext>>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

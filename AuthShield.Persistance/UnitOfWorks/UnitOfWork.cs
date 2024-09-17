using AuthShield.Application.Contracts.Persistance;
using AuthShield.Domain.Entities;
using AuthShield.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace AuthShield.Persistance.UnitOfWorks
{
    internal class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        public bool _disposed = false;
        private readonly DbContext _dbContext;
        private IDbContextTransaction? _transaction;
        private IDictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private IServiceProvider _serviceProvider;
        public UnitOfWork(Factories.IDbContextFactory<TDbContext> dBContextFactory, IServiceProvider serviceProvider)
        {
            _dbContext = dBContextFactory.CreateDbContext() ??
                throw new ArgumentNullException(nameof(dBContextFactory));
            _serviceProvider = serviceProvider;
        }

        private IService GetService<IService>()
        {
            var service = _serviceProvider.GetService(typeof(IService));

            if (service == null)
            {
                throw new InvalidOperationException($"Service registration doesn't found for {nameof(IService)}");
            }
            else
            {
                return (IService)service;
            }
            
        }

        public async Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync(isolationLevel);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                if (_transaction != null)
                    await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                if (_transaction != null)
                    await _transaction.RollbackAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                    await _transaction.DisposeAsync();
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _repositories?.Clear();
                    _transaction?.Dispose();
                    _dbContext?.Dispose();
                }
            }
            _disposed = true;
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class
        {

            if (hasCustomRepository)
            {
                var repository = _dbContext.GetService<IRepository<TEntity>>();
                return repository;
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                var repository = new Repository<TEntity>(_dbContext);
                _repositories.Add(type, repository);
            }

            return (IRepository<TEntity>)_repositories[type];

        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }

        }

        public int SaveChanges(bool ensureAutoHistory = false)
        {
            if (ensureAutoHistory)
            {
                _dbContext.EnsureAutoHistory();
            }
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
        {
            if (ensureAutoHistory)
            {
                _dbContext.EnsureAutoHistory();
            }
            return await _dbContext.SaveChangesAsync();
        }


        //Custom repository
        public IUserRepository Users => GetService<IUserRepository>();
    }
}

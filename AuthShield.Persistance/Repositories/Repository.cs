using AuthShield.Application.Contracts.Persistance;
using AuthShield.Persistance.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Persistance.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }


        private IQueryable<TEntity> QueryBuilder(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilter = false)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();


            if (disableTracking)
                query = query.AsNoTracking();

            if (ignoreQueryFilter)
                query = query.IgnoreQueryFilters();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query);

            return query;
        }

        private IQueryable<TResult> QueryBuilder<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilter = false)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();


            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (ignoreQueryFilter)
                query = query.IgnoreQueryFilters();

            if (orderBy != null)
                return orderBy(query).Select(selector);


            return query.Select(selector);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public ValueTask<TEntity> FindAsync(params object[] keyValues) => _dbSet.FindAsync(keyValues);

        public IQueryable<TEntity> GetAll() => _dbSet;


        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilter = false)
        {
            return QueryBuilder(predicate, orderBy, include, disableTracking, ignoreQueryFilter);
        }

        public virtual IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilter = false)
        {
            return QueryBuilder(selector, predicate, orderBy, include, disableTracking, ignoreQueryFilter);
        }

        public virtual async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilter = false)
        {
            IQueryable<TEntity> query = QueryBuilder(predicate, orderBy, include, disableTracking, ignoreQueryFilter);

            return await query.ToListAsync();
        }

        public virtual async Task<IList<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilter = false)
        {
            IQueryable<TResult> query = QueryBuilder(selector, predicate, orderBy, include, disableTracking, ignoreQueryFilter);
            return await query.ToListAsync();
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilter = false)
        {
            IQueryable<TEntity> query = QueryBuilder(predicate, orderBy, include, disableTracking, ignoreQueryFilter);
            return query.FirstOrDefault();
        }

        public virtual TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilter = false)
        {
            IQueryable<TResult> query = QueryBuilder(selector, predicate, orderBy, include, disableTracking, ignoreQueryFilter);
            return query.FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstOrDefaultEntityAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilter = false)
        {
            IQueryable<TEntity> query = QueryBuilder(predicate, orderBy, include, disableTracking, ignoreQueryFilter);
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<TResult> GetFirstOrDefaultProjectedAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilter = false)
        {
            IQueryable<TResult> query = QueryBuilder(selector, predicate, orderBy, include, disableTracking, ignoreQueryFilter);
            return await query.FirstOrDefaultAsync();
        }

        public IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            bool disableTracking = false,
            bool ignoreQueryFilter = false)
        {
            IQueryable<TEntity> query = QueryBuilder(predicate, orderBy, include, disableTracking, ignoreQueryFilter);
            return query.ToPagedList(pageIndex, pageSize);
        }

        public async Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            bool disableTracking = false,
            bool ignoreQueryFilter = false)
        {
            IQueryable<TEntity> query = QueryBuilder(predicate, orderBy, include, disableTracking, ignoreQueryFilter);
            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        public IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            bool disableTracking = false,
            bool ignoreQueryFilter = false) where TResult : class
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = false, bool ignoreQueryFilter = false) where TResult : class
        {
            throw new NotImplementedException();
        }
        public virtual int ExecuteRawSql(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, parameters);
        }

        public virtual async Task<int> ExecuteRawSqlAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public virtual IQueryable<TEntity> FromSql(string sql, params object[] parameters)
        {
            return _dbSet.FromSqlRaw(sql, parameters);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbSet.Count();
            else
                return _dbSet.Count(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return await _dbSet.CountAsync();
            else
                return await _dbSet.CountAsync(predicate);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbSet.Any();
            else
                return _dbSet.Any(predicate);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return await _dbSet.AnyAsync();
            else
                return await _dbSet.AnyAsync(predicate);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            return _dbSet.Entry(entity).Entity;
        }

        public virtual void Insert(params TEntity[] entities) => _dbSet.AddRange(entities);

        public virtual void Insert(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

        public virtual ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return _dbSet.AddAsync(entity, cancellationToken);
        }

        public virtual Task InsertAsync(params TEntity[] entities) => _dbSet.AddRangeAsync(entities);

        public virtual Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) => _dbSet.AddRangeAsync(entities, cancellationToken);

        public virtual TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public virtual void Update(params TEntity[] entities) => _dbSet.UpdateRange(entities);

        public virtual void Update(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

        public virtual void Delete(object id)
        {
            var key = _dbContext.Model
                .FindEntityType(typeof(TEntity))?
                .FindPrimaryKey()?
                .Properties
                .FirstOrDefault();

            var property = typeof(TEntity).GetProperty(key?.Name);

            if (property != null)
            {
                var entity = Activator.CreateInstance<TEntity>();

                property.SetValue(entity, id);

                _dbSet.Entry(entity).State = EntityState.Detached;
            }
            else
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                    _dbSet.Remove(entity);
            }
        }

        public virtual void Delete(params TEntity[] entities) => _dbSet.RemoveRange(entities);

        public virtual void Delete(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);

    }
}

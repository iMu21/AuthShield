using AuthShield.Persistance.Paging;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Application.Contracts.Persistance
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> FindAsync(params object[] keyValues);
        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false,
            bool ignoreQueryFilter = false);

        IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false,
            bool ignoreQueryFilter = false);

        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false,
            bool ignoreQueryFilter = false);

        Task<IList<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false,
            bool ignoreQueryFilter = false);


        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false,
            bool ignoreQueryFilter = false);

        TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false,
            bool ignoreQueryFilter = false);

        Task<TEntity> GetFirstOrDefaultEntityAsync(Expression<Func<TEntity, bool>> predicate = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
           bool disableTracking = false,
           bool ignoreQueryFilter = false);

        Task<TResult> GetFirstOrDefaultProjectedAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false,
            bool ignoreQueryFilter = false);


        IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            bool disableTracking = false,
            bool ignoreQueryFilter = false);

        Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            bool disableTracking = false,
            bool ignoreQueryFilter = false);

        IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
          Expression<Func<TEntity, bool>> predicate = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
          int pageIndex = 0,
          int pageSize = 20,
          bool disableTracking = false,
          bool ignoreQueryFilter = false) where TResult : class;

        Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
          Expression<Func<TEntity, bool>> predicate = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
          int pageIndex = 0,
          int pageSize = 20,
          bool disableTracking = false,
          bool ignoreQueryFilter = false) where TResult : class;

        int ExecuteRawSql(string sql, params object[] parameters);
        Task<int> ExecuteRawSqlAsync(string sql, params object[] parameters);

        IQueryable<TEntity> FromSql(string sql, params object[] parameters);

        int Count(Expression<Func<TEntity, bool>> predicate = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);


        bool Exists(Expression<Func<TEntity, bool>> predicate = null);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate = null);


        TEntity Insert(TEntity entity);
        void Insert(params TEntity[] entities);
        void Insert(IEnumerable<TEntity> entities);

        ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task InsertAsync(params TEntity[] entities);
        Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);


        TEntity Update(TEntity entity);
        void Update(params TEntity[] entities);
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// Initially try to match with primary key id, otherwise any value matched with specific entity!
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);
        void Delete(params TEntity[] entities);
        void Delete(IEnumerable<TEntity> entities);


    }
}

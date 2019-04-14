using Dapper;
using HotBag.Dapper.CrudHelper;
using HotBag.Dapper.DbFactory;
using HotBag.Data;
using HotBag.DI.Base;
using HotBag.EntityBase;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotBag.Dapper.Repository
{
    /// <summary>
    /// Implements IRepository for MongoDB.
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity for this repository</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key of the entity</typeparam>
    public class DapperRepository<TEntity, TPrimaryKey> : IDapperRepository<TEntity, TPrimaryKey>, ISingletonDependencies
        where TEntity : class, IEntityBase<TPrimaryKey>
    {
        public DapperRepository(IDatabaseFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        public DapperRepository()
        {
            DbFactory = DbFactoryProvider.GetFactory();
        }

        private IDatabaseFactory DbFactory { get; }

        public virtual TEntity Query(string sql, object param = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.Open();
                var result = db.Query<TEntity>(sql, param);
                db.Close();
                return result.FirstOrDefault();
            }
        }

        public virtual async Task<TEntity> QueryAsync(string sql, object param = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                await db.OpenAsync();
                var result = await db.QueryAsync<TEntity>(sql, param);
                db.Close();
                return result.FirstOrDefault();

            }
        }
        public virtual IEnumerable<TEntity> QueryList(string sql, object param = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.Open();
                return db.Query<TEntity>(sql, param);
            }
        }
        public virtual async Task<IEnumerable<TEntity>> QueryListAsync(string sql, object param = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                await db.OpenAsync();
                return await db.QueryAsync<TEntity>(sql, param);

            }
        }
        public virtual TEntity Get(TPrimaryKey id)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.Open();
                return db.Get<TEntity>(id);

            }
        }
        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                await db.OpenAsync();
                return await db.GetAsync<TEntity>(id); 
            }
        }
        public virtual TEntity Get(string condition, object parameters = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.Open();
                return db.Get<TEntity>(condition, parameters);

            }
        }
        public virtual async Task<TEntity> GetAsync(string condition, object parameters = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                await db.OpenAsync();
                return await db.GetAsync<TEntity>(condition, parameters);

            }
        }

        public virtual IEnumerable<TEntity> GetList(object whereConditions)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.GetList<TEntity>(whereConditions);

                }
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetListAsync(object whereConditions)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.GetListAsync<TEntity>(whereConditions);

                }
            }
        }

        public virtual IEnumerable<TEntity> GetList(string conditions,
           object parameters)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.GetList<TEntity>(conditions, parameters);

                }
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetListAsync(string conditions,
            object parameters)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.GetListAsync<TEntity>(conditions, parameters);

                }
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetJoinedList(string conditions,
           object parameters = null)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.GetJoinedList<TEntity>(conditions, parameters);

                }
            }
        }

        public virtual IEnumerable<TEntity> GetList()
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.GetList<TEntity>();

                }
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetListAsync()
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.GetListAsync<TEntity>(); 
                }
            }
        }

        public virtual IEnumerable<TEntity> GetListPaged(int pageNumber, int rowsPerPage,
           int pageSize, string conditions, string orderby, object parameters = null)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.GetListPaged<TEntity>(pageNumber, rowsPerPage, pageSize, conditions, orderby, parameters);

                }
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetListPagedAsync(int pageNumber, int rowsPerPage,
            int pageSize, string conditions, string orderby, object parameters = null)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.GetListPagedAsync<TEntity>(pageNumber, rowsPerPage, pageSize, conditions, orderby, parameters);

                }
            }
        }

        public virtual int? Insert(TEntity entityToInsert)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Insert<int?>(entityToInsert);

                }
            }
        }
        public virtual async Task<TPrimaryKey> InsertAsync(object entityToInsert)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return (TPrimaryKey)await db.InsertAsync<TPrimaryKey>(entityToInsert);

                }
            }
        }

        public virtual TKey Insert<TKey>(TEntity entityToInsert)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Insert<TKey>(entityToInsert);

                }
            }
        }
        public virtual async Task<TKey> InsertAsync<TKey>(TEntity entityToInsert)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.InsertAsync<TKey>(entityToInsert);

                }
            }
        }
        public virtual async Task<TKey> InsertAsync<TKey>(IDbConnection db, object entityToInsert, IDbTransaction transaction, int? commandTimeout)
        {
            {

                return await db.InsertAsync<TKey>(entityToInsert, transaction, commandTimeout);

            }
        }

        public virtual int Update(TEntity entityToUpdate)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Update(entityToUpdate);

                }
            }
        }
        public virtual int Update(IDbConnection db, TEntity entityToUpdate, IDbTransaction transaction, int? timeout)
        {
            {

                return db.Update(entityToUpdate, transaction, timeout);


            }
        }
        public virtual async Task<int> UpdateAsync(IDbConnection db, TEntity entityToUpdate, IDbTransaction transaction, int? commandTimeout)
        {
            {

                return await db.UpdateAsync(entityToUpdate, transaction, commandTimeout);


            }
        }
        public async Task UpdateAsync(TEntity entityToUpdate, string condition, object paramters = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                await db.OpenAsync();
                await db.UpdateAsync(entityToUpdate, condition, paramters);

            }
        }
        public virtual async Task<bool> UpdateAsync(TEntity entityToUpdate)
        {

            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                await db.OpenAsync();
                await db.UpdateAsync(entityToUpdate);
                return await Task.FromResult(true);
            }

        }
        public virtual int Delete(TEntity entityToDelete)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Delete(entityToDelete);

                }
            }
        }
        public virtual async Task<int> DeleteAsync(TEntity entityToDelete)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.DeleteAsync(entityToDelete);

                }
            }
        }
        public virtual int Delete(TPrimaryKey id)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Delete<TEntity>(id);

                }
            }
        }
        public virtual int Delete(IDbConnection db, TPrimaryKey id, IDbTransaction transaction, int? timeout)
        {
            {

                return db.Delete(id, transaction, timeout);


            }
        }
        public virtual async Task<int> DeleteAsync(TPrimaryKey id)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.DeleteAsync<TEntity>(id);

                }
            }
        }
        public virtual int Delete(int[] ids)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    db.Open();
                    return db.Delete<TEntity>(ids);

                }
            }
        }
        public virtual async Task<int> DeleteAsync(int[] ids)
        {

            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                await db.OpenAsync();
                return await db.DeleteAsync<TEntity>(ids);

            }

        }
        public virtual async Task DeleteAsync(string condition, object parameters = null)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                await db.OpenAsync();
                await db.DeleteAsync<TEntity>(condition, parameters);


            }
        }
        // int DeleteList(object whereConditions);
        public virtual async Task<int> DeleteListAsync(object whereConditions)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.DeleteListAsync<TEntity>(whereConditions);

                }
            }
        }
        public virtual async Task<int> DeleteListAsync(string conditions,
            object parameters = null)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.DeleteListAsync<TEntity>(conditions, parameters);

                }
            }
        }

        public virtual async Task<int> RecordCountAsync(string conditions = "",
            object parameters = null)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.RecordCountAsync<TEntity>(conditions, parameters);

                }
            }
        }
        public virtual async Task<int> RecordCountAsync(object whereConditions)
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.RecordCountAsync<TEntity>(whereConditions);

                }
            }
        }

        public virtual async Task<object> GetDependents()
        {
            {
                using (var db = (DbConnection)DbFactory.GetConnection())
                {
                    await db.OpenAsync();
                    return await db.GetDependents<TEntity>();

                }
            }
        }

        public virtual async Task UpdateAsDeleted(TPrimaryKey id)
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                await db.OpenAsync();
                await db.UpdateAsDeleted<TEntity>(id);


            }
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<TEntity, TPrimaryKey>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<TEntity, TPrimaryKey>.Delete(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task IBaseRepository<TEntity, TPrimaryKey>.DeleteAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task IBaseRepository<TEntity, TPrimaryKey>.DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                db.Open();
                return db.GetList<TEntity>().AsQueryable<TEntity>(); 
            }
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            using (var db = (DbConnection)DbFactory.GetConnection())
            {
                await db.OpenAsync();
                var result = db.GetListAsync<TEntity>().Result.AsQueryable();
                return await Task.FromResult(result); 
            }
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAllList()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        TEntity IBaseRepository<TEntity, TPrimaryKey>.Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TPrimaryKey InsertAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Load(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IBaseRepository<TEntity, TPrimaryKey>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IBaseRepository<TEntity, TPrimaryKey>.UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using HotBag.Data;
using HotBag.EntityBase;

namespace HotBag.Dapper.Repository
{
    public interface IDapperRepository<TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntityBase<TPrimaryKey>
    {
        int Delete(IDbConnection db, TPrimaryKey id, IDbTransaction transaction, int? timeout);
        int Delete(int[] ids);
        int Delete(TEntity entityToDelete);
        int Delete(TPrimaryKey id);
        Task<int> DeleteAsync(int[] ids);
        Task DeleteAsync(string condition, object parameters = null);
        Task<int> DeleteAsync(TEntity entityToDelete);
        Task<int> DeleteAsync(TPrimaryKey id);
        Task<int> DeleteListAsync(object whereConditions);
        Task<int> DeleteListAsync(string conditions, object parameters = null);
        TEntity Get(string condition, object parameters = null);
        TEntity Get(TPrimaryKey id);
        Task<TEntity> GetAsync(string condition, object parameters = null);
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task<object> GetDependents();
        Task<IEnumerable<TEntity>> GetJoinedList(string conditions, object parameters = null);
        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetList(object whereConditions);
        IEnumerable<TEntity> GetList(string conditions, object parameters);
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<IEnumerable<TEntity>> GetListAsync(object whereConditions);
        Task<IEnumerable<TEntity>> GetListAsync(string conditions, object parameters);
        IEnumerable<TEntity> GetListPaged(int pageNumber, int rowsPerPage, int pageSize, string conditions, string orderby, object parameters = null);
        Task<IEnumerable<TEntity>> GetListPagedAsync(int pageNumber, int rowsPerPage, int pageSize, string conditions, string orderby, object parameters = null);
        int? Insert(TEntity entityToInsert);
        TKey Insert<TKey>(TEntity entityToInsert);
        Task<TPrimaryKey> InsertAsync(object entityToInsert);
        Task<TKey> InsertAsync<TKey>(IDbConnection db, object entityToInsert, IDbTransaction transaction, int? commandTimeout);
        Task<TKey> InsertAsync<TKey>(TEntity entityToInsert);
        TEntity Query(string sql, object param = null);
        Task<TEntity> QueryAsync(string sql, object param = null);
        IEnumerable<TEntity> QueryList(string sql, object param = null);
        Task<IEnumerable<TEntity>> QueryListAsync(string sql, object param = null);
        Task<int> RecordCountAsync(string conditions = "", object parameters = null);
        Task<int> RecordCountAsync(object whereConditions);
        int Update(IDbConnection db, TEntity entityToUpdate, IDbTransaction transaction, int? timeout);
        int Update(TEntity entityToUpdate);
        Task UpdateAsDeleted(TPrimaryKey id);
        Task<int> UpdateAsync(IDbConnection db, TEntity entityToUpdate, IDbTransaction transaction, int? commandTimeout);
        Task<bool> UpdateAsync(TEntity entityToUpdate);
        Task UpdateAsync(TEntity entityToUpdate, string condition, object paramters = null);
    }
}
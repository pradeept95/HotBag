using HotBag.DI.Base;
using HotBag.EntityBase;
using HotBag.EntityFrameworkCore.UnitOfWork;
using HotBag.Exceptions;
using HotBag.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace HotBag.EntityFrameworkCore.Repository
{
    public class EFRepository<TEntity, TPrimaryKey> : IEFRepository<TEntity, TPrimaryKey> where TEntity : class, IEFEntityBase<TPrimaryKey>, IScopedDependencies
    {
        private readonly IUnitOfWork _unitOfWork;
        public EFRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets EF DbContext object.
        /// </summary>
        public virtual DbContext Context => _unitOfWork.Context;

        /// <summary>
        /// Gets DbSet for given entity.
        /// </summary>
        public virtual DbSet<TEntity> Table => _unitOfWork.Context.Set<TEntity>();

        public int Count()
        {
            return Table.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Count(predicate);
        }

        public async Task<int> CountAsync()
        {
            return await Table.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.CountAsync(predicate);
        }

        public void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        public void Delete(TPrimaryKey id)
        {
            var entity = Table.Local.FirstOrDefault(ent => EqualityComparer<TPrimaryKey>.Default.Equals(ent.Id, id));
            if (entity == null)
            {
                entity = FirstOrDefault(id);
                if (entity == null)
                {
                    return;
                }
            }

            Delete(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Table.Where(predicate);
            if (!entities.Any())
            {
                throw new EntityNotFoundException("No item found to delete", new Exception("No item found to delete"));
            }
            Table.RemoveRange(entities);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.FromResult(Table.Remove(entity));
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            var entity = await FirstOrDefaultAsync(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entites = Table.Where(predicate);
            if(!entites.Any())
            {
                throw new EntityNotFoundException($"No Entity found to Delete in : {typeof(TEntity).Name}");
            }
            foreach (var item in entites)
            {
                await DeleteAsync(item);
            } 
        }

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            return Table.FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await GetAll().FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().FirstOrDefaultAsync(predicate);
        }

        public TEntity Get(TPrimaryKey id)
        {
            return FirstOrDefault(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table.AsQueryable();
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            if (propertySelectors.IsNullOrEmpty())
            {
                return GetAll();
            }

            var query = GetAll();

            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }

            return query;
        }

        public List<TEntity> GetAllList()
        {
            return Table.ToList();
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            var entity = await FirstOrDefaultAsync(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            return entity;
        }

        public TEntity Insert(TEntity entity)
        {
            return Table.Add(entity).Entity;
        }

        public TPrimaryKey InsertAndGetId(TEntity entity)
        {
            entity = Insert(entity);
            Context.SaveChanges();
            return entity.Id;
        }

        public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            entity = await InsertAsync(entity);
            await Context.SaveChangesAsync(); 
            return entity.Id;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await Task.FromResult(Table.Add(entity).Entity);
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            return IsTransient(entity)
            ?  Insert(entity)
            :  Update(entity);
        }

        public TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            entity = InsertOrUpdate(entity);
            Context.SaveChanges();
            return entity.Id;
        }
            
        public async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            entity = await InsertOrUpdateAsync(entity);
            await Context.SaveChangesAsync(); 
            return entity.Id;
        }

        public async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return IsTransient(entity)
           ? await InsertAsync(entity)
           : await UpdateAsync(entity);
        }

        public TEntity Load(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            return Table.LongCount();
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).LongCount();
        }

        public async Task<long> LongCountAsync()
        {
            return await GetAll().LongCountAsync();
        }

        public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).LongCountAsync();
        }

        public T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().SingleAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            var entity = Get(id);
            updateAction(entity);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }

        public async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            var entity = await GetAsync(id);
            await updateAction(entity);
            return entity;
        }

        protected virtual Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var leftExpression = Expression.PropertyOrField(lambdaParam, "Id");

            Expression<Func<object>> closure = () => id;
            var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);

            var lambdaBody = Expression.Equal(leftExpression, rightExpression);

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!Table.Local.Contains(entity))
            {
                Table.Attach(entity);
            }
        }

        public DbContext GetDbContext()
        {
            return Context;
        }

        public Task EnsureCollectionLoadedAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionExpression,
          CancellationToken cancellationToken) where TProperty : class
        {
            var expression = collectionExpression.Body as MemberExpression;
            if (expression == null)
            {
                throw new Exception($"Given {nameof(collectionExpression)} is not a {typeof(MemberExpression).FullName}");
            }

            return Context.Entry(entity)
                .Collection(expression.Member.Name)
                .LoadAsync(cancellationToken);
        }

        public Task EnsurePropertyLoadedAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression,
            CancellationToken cancellationToken) where TProperty : class
        {
            return Context.Entry(entity).Reference(propertyExpression).LoadAsync(cancellationToken);
        }

        public bool IsTransient(TEntity entity)
        {
            return Table.Any(x => x.Id.Equals(entity.Id));
        }
    }
}

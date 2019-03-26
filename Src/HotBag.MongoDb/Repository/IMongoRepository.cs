using HotBag.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotBag.MongoDb.Repository
{
    //
    // Summary:
    //     This interface is implemented by all repositories to ensure implementation of
    //     fixed methods.
    //
    // Type parameters:
    //   TEntity:
    //     Main Entity type this repository works on
    //
    //   TPrimaryKey:
    //     Primary key type of the entity
    public interface IMongoRepository<TEntity, TPrimaryKey> where TEntity : class, IMongoEntityBase<TPrimaryKey>
    {
        //
        // Summary:
        //     Gets count of all entities in this repository.
        //
        // Returns:
        //     Count of entities
        int Count();
        //
        // Summary:
        //     Gets count of all entities in this repository based on given predicate.
        //
        // Parameters:
        //   predicate:
        //     A method to filter count
        //
        // Returns:
        //     Count of entities
        int Count(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Gets count of all entities in this repository based on given predicate.
        //
        // Parameters:
        //   predicate:
        //     A method to filter count
        //
        // Returns:
        //     Count of entities
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Gets count of all entities in this repository.
        //
        // Returns:
        //     Count of entities
        Task<int> CountAsync();
        //
        // Summary:
        //     Deletes an entity.
        //
        // Parameters:
        //   entity:
        //     Entity to be deleted
        void Delete(TEntity entity);
        //
        // Summary:
        //     Deletes an entity by primary key.
        //
        // Parameters:
        //   id:
        //     Primary key of the entity
        void Delete(TPrimaryKey id);
        //
        // Summary:
        //     Deletes many entities by function. Notice that: All entities fits to given predicate
        //     are retrieved and deleted. This may cause major performance problems if there
        //     are too many entities with given predicate.
        //
        // Parameters:
        //   predicate:
        //     A condition to filter entities
        void Delete(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Deletes an entity by primary key.
        //
        // Parameters:
        //   id:
        //     Primary key of the entity
        Task DeleteAsync(TPrimaryKey id);
        //
        // Summary:
        //     Deletes many entities by function. Notice that: All entities fits to given predicate
        //     are retrieved and deleted. This may cause major performance problems if there
        //     are too many entities with given predicate.
        //
        // Parameters:
        //   predicate:
        //     A condition to filter entities
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Deletes an entity.
        //
        // Parameters:
        //   entity:
        //     Entity to be deleted
        Task DeleteAsync(TEntity entity);
        //
        // Summary:
        //     Gets an entity with given given predicate or null if not found.
        //
        // Parameters:
        //   predicate:
        //     Predicate to filter entities
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Gets an entity with given primary key or null if not found.
        //
        // Parameters:
        //   id:
        //     Primary key of the entity to get
        //
        // Returns:
        //     Entity or null
        TEntity FirstOrDefault(TPrimaryKey id);
        //
        // Summary:
        //     Gets an entity with given given predicate or null if not found.
        //
        // Parameters:
        //   predicate:
        //     Predicate to filter entities
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Gets an entity with given primary key or null if not found.
        //
        // Parameters:
        //   id:
        //     Primary key of the entity to get
        //
        // Returns:
        //     Entity or null
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
        //
        // Summary:
        //     Gets an entity with given primary key.
        //
        // Parameters:
        //   id:
        //     Primary key of the entity to get
        //
        // Returns:
        //     Entity
        TEntity Get(TPrimaryKey id);
        //
        // Summary:
        //     Used to get a IQueryable that is used to retrieve entities from entire table.
        //
        // Returns:
        //     IQueryable to be used to select entities from database
        IQueryable<TEntity> GetAll();
        //
        // Summary:
        //     Used to get a IQueryable that is used to retrieve entities from entire table.
        //     One or more
        //
        // Parameters:
        //   propertySelectors:
        //     A list of include expressions.
        //
        // Returns:
        //     IQueryable to be used to select entities from database
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);
        //
        // Summary:
        //     Used to get all entities based on given predicate.
        //
        // Parameters:
        //   predicate:
        //     A condition to filter entities
        //
        // Returns:
        //     List of all entities
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Used to get all entities.
        //
        // Returns:
        //     List of all entities
        List<TEntity> GetAllList();
        //
        // Summary:
        //     Used to get all entities based on given predicate.
        //
        // Parameters:
        //   predicate:
        //     A condition to filter entities
        //
        // Returns:
        //     List of all entities
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Used to get all entities.
        //
        // Returns:
        //     List of all entities
        Task<List<TEntity>> GetAllListAsync();
        //
        // Summary:
        //     Gets an entity with given primary key.
        //
        // Parameters:
        //   id:
        //     Primary key of the entity to get
        //
        // Returns:
        //     Entity
        Task<TEntity> GetAsync(TPrimaryKey id);
        //
        // Summary:
        //     Inserts a new entity.
        //
        // Parameters:
        //   entity:
        //     Inserted entity
        TEntity Insert(TEntity entity);
        //
        // Summary:
        //     Inserts a new entity and gets it's Id. It may require to save current unit of
        //     work to be able to retrieve id.
        //
        // Parameters:
        //   entity:
        //     Entity
        //
        // Returns:
        //     Id of the entity
        TPrimaryKey InsertAndGetId(TEntity entity);
        //
        // Summary:
        //     Inserts a new entity and gets it's Id. It may require to save current unit of
        //     work to be able to retrieve id.
        //
        // Parameters:
        //   entity:
        //     Entity
        //
        // Returns:
        //     Id of the entity
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        //
        // Summary:
        //     Inserts a new entity.
        //
        // Parameters:
        //   entity:
        //     Inserted entity
        Task<TEntity> InsertAsync(TEntity entity);
        //
        // Summary:
        //     Inserts or updates given entity depending on Id's value.
        //
        // Parameters:
        //   entity:
        //     Entity
        TEntity InsertOrUpdate(TEntity entity);
        //
        // Summary:
        //     Inserts or updates given entity depending on Id's value. Also returns Id of the
        //     entity. It may require to save current unit of work to be able to retrieve id.
        //
        // Parameters:
        //   entity:
        //     Entity
        //
        // Returns:
        //     Id of the entity
        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);
        //
        // Summary:
        //     Inserts or updates given entity depending on Id's value. Also returns Id of the
        //     entity. It may require to save current unit of work to be able to retrieve id.
        //
        // Parameters:
        //   entity:
        //     Entity
        //
        // Returns:
        //     Id of the entity
        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);
        //
        // Summary:
        //     Inserts or updates given entity depending on Id's value.
        //
        // Parameters:
        //   entity:
        //     Entity
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        //
        // Summary:
        //     Creates an entity with given primary key without database access.
        //
        // Parameters:
        //   id:
        //     Primary key of the entity to load
        //
        // Returns:
        //     Entity
        TEntity Load(TPrimaryKey id);
        //
        // Summary:
        //     Gets count of all entities in this repository based on given predicate (use this
        //     overload if expected return value is greather than System.Int32.MaxValue).
        //
        // Parameters:
        //   predicate:
        //     A method to filter count
        //
        // Returns:
        //     Count of entities
        long LongCount(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Gets count of all entities in this repository (use if expected return value is
        //     greather than System.Int32.MaxValue.
        //
        // Returns:
        //     Count of entities
        long LongCount();
        //
        // Summary:
        //     Gets count of all entities in this repository (use if expected return value is
        //     greather than System.Int32.MaxValue.
        //
        // Returns:
        //     Count of entities
        Task<long> LongCountAsync();
        //
        // Summary:
        //     Gets count of all entities in this repository based on given predicate (use this
        //     overload if expected return value is greather than System.Int32.MaxValue).
        //
        // Parameters:
        //   predicate:
        //     A method to filter count
        //
        // Returns:
        //     Count of entities
        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Used to run a query over entire entities. HotBag.Domain.Uow.UnitOfWorkAttribute
        //     attribute is not always necessary (as opposite to HotBag.Domain.Repositories.IRepository`2.GetAll)
        //     if queryMethod finishes IQueryable with ToList, FirstOrDefault etc..
        //
        // Parameters:
        //   queryMethod:
        //     This method is used to query over entities
        //
        // Type parameters:
        //   T:
        //     Type of return value of this method
        //
        // Returns:
        //     Query result
        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);
        //
        // Summary:
        //     Gets exactly one entity with given predicate. Throws exception if no entity or
        //     more than one entity.
        //
        // Parameters:
        //   predicate:
        //     Entity
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Gets exactly one entity with given predicate. Throws exception if no entity or
        //     more than one entity.
        //
        // Parameters:
        //   predicate:
        //     Entity
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        //
        // Summary:
        //     Updates an existing entity.
        //
        // Parameters:
        //   entity:
        //     Entity
        TEntity Update(TEntity entity);
        //
        // Summary:
        //     Updates an existing entity.
        //
        // Parameters:
        //   id:
        //     Id of the entity
        //
        //   updateAction:
        //     Action that can be used to change values of the entity
        //
        // Returns:
        //     Updated entity
        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);
        //
        // Summary:
        //     Updates an existing entity.
        //
        // Parameters:
        //   id:
        //     Id of the entity
        //
        //   updateAction:
        //     Action that can be used to change values of the entity
        //
        // Returns:
        //     Updated entity
        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);
        //
        // Summary:
        //     Updates an existing entity.
        //
        // Parameters:
        //   entity:
        //     Entity
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}

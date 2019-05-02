using HotBag.Data;
using HotBag.DI.Base;
using HotBag.EntityBase;
using HotBag.OptionConfigurer.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotBag.MongoDb.Repository
{
    /// <summary>
    /// Implements IRepository for MongoDB.
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity for this repository</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key of the entity</typeparam>
    public class MongoRepository<TEntity, TPrimaryKey> : IMongoRepository<TEntity, TPrimaryKey>, ISingletonDependencies
        where TEntity : class, IEntityBase<TPrimaryKey> 
    {
        private readonly IMongoDatabase _database = null;

        public MongoRepository(IOptions<MongoDbSettings> mongoConfiguration)
        {

            var client = new MongoClient(mongoConfiguration.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(mongoConfiguration.Value.Database);
        }

        public virtual IMongoCollection<TEntity> Collection
        {
            get
            {
                return _database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return Collection.Find(_ => true).ToList().AsQueryable();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(Collection.AsQueryable());
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }

        public TEntity Get(TPrimaryKey id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(m => m.Id, id);
            var entity = Collection.Find(filter);
            if (entity == null)
            {
                throw new System.Exception("There is no such an entity with given primary key. Entity type: " + typeof(TEntity).FullName + ", primary key: " + id);
            }

            return (TEntity)entity;
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(m => m.Id, id);
            var entity = await Collection.FindAsync(filter);
            if (entity == null)
            {
                throw new System.Exception("There is no such an entity with given primary key. Entity type: " + typeof(TEntity).FullName + ", primary key: " + id);
            }
            return  await entity.FirstOrDefaultAsync();
        }

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(m => m.Id, id);
            return (TEntity)Collection.Find<TEntity>(filter).FirstOrDefault();
        }

        public TEntity Insert(TEntity entity)
        {
            Collection.InsertOne(entity);
            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity.Id;
        }

        public TEntity Update(TEntity entity)
        {
            ReplaceOneResult actionResult = Collection.ReplaceOne(n => n.Id.Equals(entity.Id)
                                            , entity
                                            , new UpdateOptions { IsUpsert = true });
            if (!(actionResult.IsAcknowledged
                 && actionResult.ModifiedCount > 0))
            {
                throw new System.Exception("Unalbe to update entity.");
            }
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            ReplaceOneResult actionResult = await Collection.ReplaceOneAsync(n => n.Id.Equals(entity.Id)
                                           , entity
                                           , new UpdateOptions { IsUpsert = true });
            if (!(actionResult.IsAcknowledged
                 && actionResult.ModifiedCount > 0))
            {
                throw new System.Exception("Unalbe to update entity.");
            }
            return entity;
        }

        public void Delete(TEntity entity)
        {
            //FindOptions<BsonDocument> options = new FindOptions<BsonDocument>
            //{
            //    BatchSize = 2,
            //    NoCursorTimeout = false
            //};

            Delete(entity.Id);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await DeleteAsync(entity.Id);
        }

        public void Delete(TPrimaryKey id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(m => m.Id, id); 
            Collection.DeleteOne(filter);
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(m => m.Id, id);
            await Collection.DeleteOneAsync(filter); 
        }

        public Task<TEntity> UpdateAsync(ObjectId id, Func<TEntity, Task> updateAction)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return (int)Collection.CountDocuments(new BsonDocument());
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return (int)Collection.CountDocuments(new BsonDocument());
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync()
        {
           return Convert.ToInt32(await Collection.CountDocumentsAsync(new BsonDocument()));
        } 

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(ObjectId id)
        {
            throw new NotImplementedException();
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

        public Task<TEntity> GetAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public ObjectId InsertAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public ObjectId InsertOrUpdateAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ObjectId> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Load(ObjectId id)
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

        public TEntity Update(ObjectId id, Action<TEntity> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity Load(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        TPrimaryKey IBaseRepository<TEntity, TPrimaryKey>.InsertAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TPrimaryKey IBaseRepository<TEntity, TPrimaryKey>.InsertOrUpdateAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<TPrimaryKey> IBaseRepository<TEntity, TPrimaryKey>.InsertOrUpdateAndGetIdAsync(TEntity entity)
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

        public async Task SaveChangeAsync()
        {
            //throw new NotImplementedException();
        }

        public void SaveChange()
        {
           // throw new NotImplementedException();
        }
    }
}

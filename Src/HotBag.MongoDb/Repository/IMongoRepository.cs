using HotBag.Data;
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
    public interface IMongoRepository<TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntityBase<TPrimaryKey> 
    {
        
    }
}

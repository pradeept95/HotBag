using HotBag.MongoDb.Context;
using System;
using System.Threading.Tasks;

namespace HotBag.MongoDb.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IMongoDbContext Context { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    } 
}

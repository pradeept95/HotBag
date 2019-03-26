using HotBag.EntityFrameworkCore.Context;
using System;
using System.Threading.Tasks;

namespace HotBag.EntityFrameworkCore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext Context { get; }
        void Commit();
        Task CommitAsync();
    } 
}

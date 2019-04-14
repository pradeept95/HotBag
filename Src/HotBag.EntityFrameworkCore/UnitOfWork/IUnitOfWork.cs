using HotBag.Data;
using HotBag.EntityFrameworkCore.Context;
using System;
using System.Threading.Tasks;

namespace HotBag.EntityFrameworkCore.UnitOfWork
{
    public interface IUnitOfWork : IBaseUnitOfWork 
    {
        ApplicationDbContext Context { get; } 
    } 
}

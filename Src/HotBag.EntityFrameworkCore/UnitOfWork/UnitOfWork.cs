using HotBag.DI.Base;
using HotBag.EntityFrameworkCore.Context;
using System.Threading.Tasks;

namespace HotBag.EntityFrameworkCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IScopedDependencies
    {
        public ApplicationDbContext Context { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void OpenConnection()
        {
            
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();

        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
 
}

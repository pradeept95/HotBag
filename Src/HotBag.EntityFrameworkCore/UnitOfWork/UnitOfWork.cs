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
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void OpenConnection()
        {
            
        }

        public async Task CommitAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {

                throw;
            }
           
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
 
}

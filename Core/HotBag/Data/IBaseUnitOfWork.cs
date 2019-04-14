using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotBag.Data
{
    public interface IBaseUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

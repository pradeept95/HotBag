using HotBag.Data;
using HotBag.EntityBase;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotBag.Services.RepositoryFactory
{
    public interface IRepositoryFactory<TEntity, TPrimaryKey> 
        where TEntity : class, IEntityBase<TPrimaryKey>
    {
        IBaseRepository<TEntity, TPrimaryKey> GetRepository();
    }
}

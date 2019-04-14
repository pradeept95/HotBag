using HotBag.Data;
using HotBag.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotBag.EntityFrameworkCore.Repository
{
    public interface IEFRepository<TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntityBase<TPrimaryKey>
    {
    }
}

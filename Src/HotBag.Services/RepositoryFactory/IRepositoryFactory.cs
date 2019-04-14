using HotBag.Dapper.Repository;
using HotBag.Data;
using HotBag.DI.Base;
using HotBag.EntityBase;
using HotBag.EntityFrameworkCore.Repository;
using HotBag.MongoDb.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
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
    public class RepositoryFactory<TEntity, TPrimaryKey> : IRepositoryFactory<TEntity, TPrimaryKey>, ITransientDependencies
        where TEntity : class, IEntityBase<TPrimaryKey>
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositoryFactory(IServiceCollection serviceCollection)
        {
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public IBaseRepository<TEntity, TPrimaryKey> GetRepository()
        {
            DatabaseORM databaseProvider = DatabaseORM.EntityFrameworkCore;
            IBaseRepository<TEntity, TPrimaryKey> currentRepository = null;
            switch (databaseProvider)
            {
                case DatabaseORM.MongoDB:
                    currentRepository = _serviceProvider.GetService<IMongoRepository<TEntity, TPrimaryKey>>();
                    break;
                case DatabaseORM.EntityFrameworkCore:
                    currentRepository = _serviceProvider.GetService<IEFRepository<TEntity, TPrimaryKey>>();
                    break;
                case DatabaseORM.Dapper:
                    currentRepository = _serviceProvider.GetService<IDapperRepository<TEntity, TPrimaryKey>>();
                    break;
                default:
                    currentRepository = _serviceProvider.GetService<IEFRepository<TEntity, TPrimaryKey>>();
                    break;
            } 
            return currentRepository;
        }
    }
}

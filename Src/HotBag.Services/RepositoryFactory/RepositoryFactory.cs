using HotBag.Configuration.Global.Application;
using HotBag.Dapper.Repository;
using HotBag.Data;
using HotBag.DI.Base;
using HotBag.EntityBase;
using HotBag.EntityFrameworkCore.Repository;
using HotBag.MongoDb.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HotBag.Services.RepositoryFactory
{
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
            //test
            var someclass = IocManager.Configurations.Manager.GetService<IApplicationSetting>();



            DatabaseORM databaseProvider = HotBagConfiguration.Configurations.ObjectRelationMappings.CurrentSelectedORM;
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

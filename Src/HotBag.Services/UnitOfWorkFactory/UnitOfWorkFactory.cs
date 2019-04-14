//using HotBag.Dapper.Repository;
//using HotBag.Data;
//using HotBag.DI.Base;
//using HotBag.EntityBase;
//using HotBag.EntityFrameworkCore.Repository;
//using HotBag.MongoDb.Repository;
//using Microsoft.Extensions.DependencyInjection;
//using System;

//namespace HotBag.Services.UnitOfWork
//{
//    public class UnitOfWorkFactory : IUnitOfWorkFactory 
//    {
//        private readonly IServiceProvider _serviceProvider;
//        public UnitOfWorkFactory(IServiceCollection serviceCollection)
//        {
//            _serviceProvider = serviceCollection.BuildServiceProvider();
//        } 

//        public IBaseUnitOfWork GetCurrentUnitOfWork()
//        {
//            DatabaseORM databaseProvider = DatabaseORM.EntityFrameworkCore; //get this value form globla setting
//            IBaseUnitOfWork currentRepository = null;
//            switch (databaseProvider)
//            {
//                case DatabaseORM.MongoDB:
//                    currentRepository = _serviceProvider.GetRequiredService<HotBag.MongoDb.UnitOfWork.IUnitOfWork>();
//                    break;
//                case DatabaseORM.EntityFrameworkCore:
//                    //currentRepository = _serviceProvider.GetRequiredService<HotBag.EntityFrameworkCore.UnitOfWork.IUnitOfWork>();
//                    break;
//                case DatabaseORM.Dapper:
//                    //currentRepository = _serviceProvider.GetService<>();
//                    break;
//                default:
//                    //currentRepository = _serviceProvider.GetRequiredService<HotBag.EntityFrameworkCore.UnitOfWork.IUnitOfWork>();
//                    break;
//            } 
//            return currentRepository;
//        }
//    }
//}

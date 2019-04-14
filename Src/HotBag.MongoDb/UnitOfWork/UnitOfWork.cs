//using HotBag.DI.Base;
//using HotBag.MongoDb.Context;
//using System.Threading.Tasks;

//namespace HotBag.MongoDb.UnitOfWork
//{
//    public class UnitOfWork : IUnitOfWork, IScopedDependencies
//    {
//        public IMongoDbContext Context { get; }
         

//        public UnitOfWork(IMongoDbContext context)
//        {
//            Context = context;
//        }
//        public void SaveChanges()
//        { 
//            //unit of work is not available to mongo db
//        }

//        public void OpenConnection()
//        {
            
//        }

//        public async Task SaveChangesAsync()
//        {
//            //unit of work is not available to mongo db 
//        }

//        public void Dispose()
//        { 
//        }
//    }
 
//}

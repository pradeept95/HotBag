using Core.Log;
using System;
using System.Data;

namespace HotBag.Dapper.DbFactory
{
    public interface IDatabaseFactory : IDisposable
    {
        IDbConnection Db { get; }
        Dialect Dialect { get; }
        QueryBuilder QueryBuilder { get; }
        IDbConnection GetConnection();
        ILogger DbLogger { get; set; }
    }

}

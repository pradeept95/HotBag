
using HotBag.SqlTemplate.MsSQL;
using HotBag.SqlTemplate.MySQL;
using HotBag.SqlTemplate.PostgressSQL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using System;

namespace HotBag.Dapper.DbFactory
{
    /// <summary>
    /// This class is a factory class that creates 
    /// data-base specific factories which in turn create data acces objects
    /// </summary>
    public class DatabaseFactories
    {
        /// <summary>
        ///  gets a provider specific (i.e. database specific) factory 
        /// </summary>
        /// <param name="dialect"></param>
        /// <param name="serviceProvider"></param>
        /// <returns>an instance of service factory of given provider.</returns>
        public static IDatabaseFactory GetFactory()
        {
            return DbFactoryProvider.GetFactory();
        } 

        public static IDatabaseFactory SetFactory(Dialect dialect, IServiceProvider serviceProvider)
        {
            // return the requested DaoFactory
            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
            IDatabaseFactory myFactory;
            switch (dialect)
            {
                //instance of corresponding provider
                case Dialect.MySQL:
                    var mySqldbfactory = new MySQLFactory(configuration, serviceProvider);
                    DbFactoryProvider.SetCurrentDbFactory(mySqldbfactory);
                    myFactory = DbFactoryProvider.GetFactory();
                    break;
                case Dialect.PostgreSQL:
                    var npgsqlFactory = new NpgSqlFactory(configuration, serviceProvider);
                    DbFactoryProvider.SetCurrentDbFactory(npgsqlFactory);
                    myFactory = DbFactoryProvider.GetFactory();
                    break;
                case Dialect.SQLServer:

                    var dbfactory = new MsSQLFactory(configuration, serviceProvider);
                    DbFactoryProvider.SetCurrentDbFactory(dbfactory);
                    myFactory =  DbFactoryProvider.GetFactory();
                    break;
                //case Dialect.SQLite:
                //    break;

                default:
                    var dbFactory = new MsSQLFactory(configuration, serviceProvider);
                    DbFactoryProvider.SetCurrentDbFactory(dbFactory);
                    myFactory =  DbFactoryProvider.GetFactory();
                    break;
            }
            return myFactory;
        }
    }

}

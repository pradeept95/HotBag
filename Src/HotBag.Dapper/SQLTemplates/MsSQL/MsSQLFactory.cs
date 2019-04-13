using System;
using System.Data;
using System.Data.SqlClient;
using Core.Log;
using HotBag.Dapper;
using HotBag.Dapper.DbFactory;
using HotBag.Dapper.SqlTemplate.MsSQL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.SqlTemplate.MsSQL
{
    /// <summary>
    /// 
    /// </summary>
    public class MsSQLFactory : IDatabaseFactory
    {
        public IDbConnection Db { get; set; }
        public Dialect Dialect => Dialect.SQLServer;

        public QueryBuilder QueryBuilder { get; }

        private readonly string _connectionString;

        public IDbConnection GetConnection()
        {
            Db = new SqlConnection(_connectionString);
            return Db;
        }
        //in appsetting file
        //      "DBInfo": {
        //  "Name": "coresample",
        //  "ConnectionString": "User ID=postgres;Password=xxxxxx;Host=localhost;Port=5432;Database=coresample;Pooling=true;"
        //}
        public MsSQLFactory(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            //IConfiguration configuration
            // connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
            _connectionString = configuration["Configuration:EntityFramework:ConnectionString:Default"];// ConfigurationManager.ConnectionStrings[connectionStringName].ToString();
            Db = new SqlConnection(_connectionString);
            QueryBuilder = new MsSqlQueryBuilder(new MsSQLTemplate());
            var hostingenv = serviceProvider.GetService<IHostingEnvironment>();
            DbLogger = new DbLogger(hostingenv,new DefaultDbLoggerSetting());
        }

        public void Dispose()
        {
            if (Db.State == ConnectionState.Open)
                Db.Close();
            Db.Close();
            //db.Dispose();
        }

        public ILogger DbLogger { get; set; }
    }


}
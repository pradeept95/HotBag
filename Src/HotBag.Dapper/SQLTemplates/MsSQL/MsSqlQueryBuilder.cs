using HotBag.Dapper;
using HotBag.Dapper.Resolver;

namespace HotBag.SqlTemplate.MsSQL
{
    public sealed class MsSqlQueryBuilder : QueryBuilder
    {       
        public MsSqlQueryBuilder(ISQLTemplate template, ITableNameResolver tblresolver, IColumnNameResolver colresolver) 
          : base(template, tblresolver, colresolver)
        {
        }
        public MsSqlQueryBuilder(ISQLTemplate template)
         : base(template)
        {
        }
    }
}
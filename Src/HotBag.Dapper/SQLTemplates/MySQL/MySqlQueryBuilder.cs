
using HotBag.Dapper;
using HotBag.Dapper.Resolver;

namespace HotBag.SqlTemplate.MySQL
{
    public sealed class MySqlQueryBuilder : QueryBuilder
    {       
        public MySqlQueryBuilder(ISQLTemplate template, ITableNameResolver tblresolver, IColumnNameResolver colresolver) 
          : base(template, tblresolver, colresolver)
        {
        }
        public MySqlQueryBuilder(ISQLTemplate template)
         : base(template)
        {
        }
    }
}
using System;

namespace HotBag.Dapper.Resolver
{
    public interface ITableNameResolver
    {
        string ResolveTableName(Type type);
    }
}
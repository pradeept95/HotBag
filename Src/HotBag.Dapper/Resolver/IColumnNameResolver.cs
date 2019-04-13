using System.Reflection;

namespace HotBag.Dapper.Resolver
{
    public interface IColumnNameResolver
    {
        string ResolveColumnName(PropertyInfo propertyInfo);
    }
}
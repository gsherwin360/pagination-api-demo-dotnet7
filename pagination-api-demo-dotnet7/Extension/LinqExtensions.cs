using System.Linq.Expressions;
using System.Reflection;

namespace pagination_api_demo_dotnet7.Extension;

/// <summary>
/// Provides extension methods for dynamically ordering IQueryable collections by property name.
/// </summary>
public static class LinqExtensions
{
    private static PropertyInfo GetPropertyInfo(Type objType, string name)
    {
        var properties = objType.GetProperties();
        var matchedProperty = properties.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        if (matchedProperty == null)
            throw new ArgumentException("Property not found: " + name, nameof(name));

        return matchedProperty;
    }

    private static LambdaExpression GetOrderExpression(Type objType, PropertyInfo pi)
    {
        var paramExpr = Expression.Parameter(objType);
        var propAccess = Expression.PropertyOrField(paramExpr, pi.Name);
        var expr = Expression.Lambda(propAccess, paramExpr);

        return expr;
    }

    public static IQueryable<T> OrderByString<T>(this IQueryable<T> query, string name)
    {
        var propInfo = GetPropertyInfo(typeof(T), name);
        var expr = GetOrderExpression(typeof(T), propInfo);

        var method = typeof(Queryable).GetMethods().FirstOrDefault(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
        var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);

        return (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
    }

    public static IQueryable<T> OrderByStringDescending<T>(this IQueryable<T> query, string name)
    {
        var propInfo = GetPropertyInfo(typeof(T), name);
        var expr = GetOrderExpression(typeof(T), propInfo);

        var method = typeof(Queryable).GetMethods().FirstOrDefault(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2);
        var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);

        return (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
    }
}
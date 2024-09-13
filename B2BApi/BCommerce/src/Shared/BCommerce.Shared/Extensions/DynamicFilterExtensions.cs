using System.Linq.Expressions;

namespace BCommerce.Shared.Extensions
{
    public static class DynamicFilterExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, string columnName, string operation, object value)
        {
            if (query == null || string.IsNullOrEmpty(columnName) || value is null)
                return query;

            if (string.IsNullOrEmpty(operation))
                operation = "equals";

            // Get the type of the elements in the data
            var elementType = typeof(T);

            // Get the property based on the column name
            var property = elementType.GetProperty(columnName);

            if (property == null)
                throw new ArgumentException($"Column '{columnName}' not found in type '{elementType}'");

            // Build the expression for the property access
            var parameter = Expression.Parameter(elementType, "x");
            var propertyAccess = Expression.Property(parameter, property);

            var convertedValue = value is IConvertible
                ? Convert.ChangeType(value, propertyAccess.Type)
                : value;

            // Create an expression based on the operation
            Expression<Func<T, bool>> predicate;
            switch (operation.ToLower())
            {
                case "equals":
                    predicate = Expression.Lambda<Func<T, bool>>(
                        Expression.Equal(propertyAccess, Expression.Constant(convertedValue)), parameter);
                    break;
                case "notequals":
                    predicate = Expression.Lambda<Func<T, bool>>(
                        Expression.NotEqual(propertyAccess, Expression.Constant(convertedValue)), parameter);
                    break;
                case "contains" when propertyAccess.Type != typeof(string):
                    predicate = x => true;
                    break;
                case "doesnotcontain" when propertyAccess.Type != typeof(string):
                    predicate = x => true;
                    break;
                case "contains":
                    predicate = Expression.Lambda<Func<T, bool>>(
                        Expression.Call(propertyAccess, "Contains", Type.EmptyTypes, Expression.Constant(convertedValue)), parameter);
                    break;
                case "doesnotcontain":
                    predicate = Expression.Lambda<Func<T, bool>>(
                        Expression.Not(Expression.Call(propertyAccess, "Contains", Type.EmptyTypes, Expression.Constant(convertedValue))), parameter);
                    break;
                // Add more cases for other operations as needed
                default:
                    throw new ArgumentException($"Unsupported operation: {operation}");
            }

            // Apply the predicate to the query
            return query.Where(predicate);
        }

        public static async Task<IQueryable<T>> FilterAsync<T>(this IQueryable<T> query, string columnName, string operation, object value)
        {
            if (query == null || string.IsNullOrEmpty(columnName) || value is null)
                return query;

            if (string.IsNullOrEmpty(operation))
                operation = "equals";

            // Get the type of the elements in the data
            var elementType = typeof(T);

            // Get the property based on the column name
            var property = elementType.GetProperty(columnName);

            if (property == null)
                throw new ArgumentException($"Column '{columnName}' not found in type '{elementType}'");

            // Build the expression for the property access
            var parameter = Expression.Parameter(elementType, "x");
            var propertyAccess = Expression.Property(parameter, property);

            var convertedValue = value is IConvertible
                ? Convert.ChangeType(value, propertyAccess.Type)
                : value;

            // Create an expression based on the operation
            Expression<Func<T, bool>> predicate;
            switch (operation.ToLower())
            {
                case "equals":
                    predicate = Expression.Lambda<Func<T, bool>>(
                        Expression.Equal(propertyAccess, Expression.Constant(convertedValue)), parameter);
                    break;
                case "notequals":
                    predicate = Expression.Lambda<Func<T, bool>>(
                        Expression.NotEqual(propertyAccess, Expression.Constant(convertedValue)), parameter);
                    break;
                case "contains" when propertyAccess.Type != typeof(string):
                    predicate = x => true;
                    break;
                case "doesnotcontain" when propertyAccess.Type != typeof(string):
                    predicate = x => true;
                    break;
                case "contains":
                    predicate = Expression.Lambda<Func<T, bool>>(
                        Expression.Call(propertyAccess, "Contains", Type.EmptyTypes, Expression.Constant(convertedValue)), parameter);
                    break;
                case "doesnotcontain":
                    predicate = Expression.Lambda<Func<T, bool>>(
                        Expression.Not(Expression.Call(propertyAccess, "Contains", Type.EmptyTypes, Expression.Constant(convertedValue))), parameter);
                    break;
                // Add more cases for other operations as needed
                default:
                    throw new ArgumentException($"Unsupported operation: {operation}");
            }

            // Apply the predicate to the query
            return query.Where(predicate);
        }
    }
}

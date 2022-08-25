using System.Linq.Expressions;

namespace GroupByExample.Extensions
{
    internal static class LinqExtensions
    {
        //https://stackoverflow.com/questions/17680840/multi-column-group-by-expression-tree
        public static IEnumerable<IGrouping<TKey?, TElement>>? GroupBy<TKey, TElement>(
            this IEnumerable<TElement> elements,
            string propertyName)
        {
            return elements.GroupBy(GetGroupKey<TElement, TKey>(propertyName).Compile());
        }

        //example:
        //Order.Id
        //Order.Client
        //Order.Client.FirstName
        static Expression? GetDeepPropertyExpression(Expression initialInstance, string property)
        {
            Expression? result = null;
            var properies = property.Split('.');

            foreach (var propertyName in properies)
            {
                var instance = result ?? initialInstance;

                result = Expression.Property(instance, propertyName);
            }

            return result;
        }

        static Expression<Func<TElement, TKey>> GetGroupKey<TElement, TKey>(params string[] properties)
        {
            if (!properties.Any())
            {
                throw new ArgumentException("At least one property needs to be specified", nameof(properties));
            }

            var typeOfT = typeof(TElement);

            var parameterExpression = Expression.Parameter(type: typeOfT);

            var propertyExpressions = properties.Select(x => GetDeepPropertyExpression(parameterExpression, x));

            Expression? bodyExpression = null;
            if (propertyExpressions.Count() == 1)
            {
                bodyExpression = propertyExpressions.ElementAt(0);
            }
            else
            {
                var separatorExpression = Expression.Constant(";");
                var typeOfString = typeof(string);

                var concatMethod = typeOfString.GetMethod(
                    name: "Concat",
                    types: new[] 
                    { 
                        typeOfString,
                        typeOfString,
                        typeOfString
                    });

                bodyExpression = propertyExpressions.Aggregate((x, y) => Expression.Call(
                    method: concatMethod,
                    arg0: x,
                    arg1: separatorExpression,
                    arg2: y));
            }

            return Expression.Lambda<Func<TElement, TKey>>(body: bodyExpression, parameters: parameterExpression);
        }
    }
}

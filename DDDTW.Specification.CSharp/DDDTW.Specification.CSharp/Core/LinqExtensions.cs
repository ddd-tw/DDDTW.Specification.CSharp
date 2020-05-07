using System.Collections.Generic;
using System.Linq;
using DDDTW.Specification.CSharp.Core.Interfaces;

namespace DDDTW.Specification.CSharp.Core
{
    public static class LinqExtensions
    {
        public static IQueryable<TEntity> RunSpec<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification, bool skipSort = false)
            where TEntity : class
        {
            var configuration = specification.Internal;
            var querySpecification = configuration.QuerySpecification;
            var orderSpecifications = configuration.OrderSpecifications;

            if (querySpecification.AsExpression() != null)
            {
                query = query.Where(querySpecification.AsExpression());
            }

            if (skipSort)
            {
                return query;
            }

            var ordered = orderSpecifications.FirstOrDefault()?.InvokeSort(query);
            for (var i = 1; i < orderSpecifications.Count; i++)
            {
                ordered = orderSpecifications[i].InvokeSort(ordered);
            }

            return SkipTake(ordered ?? query, configuration);
        }

        public static IEnumerable<TEntity> RunSpec<TEntity>(this IEnumerable<TEntity> collection, ISpecification<TEntity> specification, bool skipSort = false)
            where TEntity : class
        {
            var configuration = specification.Internal;
            var querySpecification = configuration.QuerySpecification;
            var orderSpecifications = configuration.OrderSpecifications;

            if (querySpecification.AsExpression() != null)
            {
                collection = collection.Where(querySpecification.AsFunc());
            }

            if (skipSort)
            {
                return collection;
            }

            var ordered = orderSpecifications.FirstOrDefault()?.InvokeSort(collection);
            for (var i = 1; i < orderSpecifications.Count; i++)
            {
                ordered = orderSpecifications[i].InvokeSort(ordered);
            }

            return SkipTake(ordered ?? collection, configuration);
        }

        #region Private Methods

        private static IQueryable<TEntity> SkipTake<TEntity>(IQueryable<TEntity> query, Configuration<TEntity> configuration)
            where TEntity : class
        {
            if (configuration.Skip.HasValue)
            {
                query = query.Skip(configuration.Skip.Value);
            }

            if (configuration.Take.HasValue)
            {
                query = query.Take(configuration.Take.Value);
            }

            return query;
        }

        private static IEnumerable<TEntity> SkipTake<TEntity>(IEnumerable<TEntity> collection, Configuration<TEntity> configuration)
            where TEntity : class
        {
            if (configuration.Skip.HasValue)
            {
                collection = collection.Skip(configuration.Skip.Value);
            }

            if (configuration.Take.HasValue)
            {
                collection = collection.Take(configuration.Take.Value);
            }

            return collection;
        }

        #endregion Private Methods
    }
}
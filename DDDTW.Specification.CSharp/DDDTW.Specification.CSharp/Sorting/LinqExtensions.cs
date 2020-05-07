using System.Collections.Generic;
using System.Linq;
using DDDTW.Specification.CSharp.Core.Interfaces;

namespace DDDTW.Specification.CSharp.Sorting
{
    public static class LinqExtensions
    {
        #region Order Methods

        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, IOrderSpecification<TEntity> orderSpecification)
            where TEntity : class
        {
            return orderSpecification.InvokeSort(query);
        }

        public static IOrderedEnumerable<TEntity> OrderBy<TEntity>(this IEnumerable<TEntity> collection, IOrderSpecification<TEntity> orderSpecification)
            where TEntity : class
        {
            return orderSpecification.InvokeSort(collection);
        }

        #endregion Order Methods

        #region Then Methods

        public static IOrderedQueryable<TEntity> ThenBy<TEntity>(this IOrderedQueryable<TEntity> query, IOrderSpecification<TEntity> orderSpecification)
            where TEntity : class
        {
            return orderSpecification.InvokeSort(query);
        }

        public static IOrderedEnumerable<TEntity> ThenBy<TEntity>(this IOrderedEnumerable<TEntity> collection, IOrderSpecification<TEntity> orderSpecification)
            where TEntity : class
        {
            return orderSpecification.InvokeSort(collection);
        }

        #endregion Then Methods
    }
}